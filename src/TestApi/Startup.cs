using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MTech;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var animalFarmConnectionString = Configuration.GetConnectionString("AnimalFarm");

            services.AddScoped<IWeatherService>(impl => new MTech.DapperSample.WeatherService(new SqlConnection(connectionString)));

            connectionString = Configuration.GetConnectionString("TodoList");
            // Dapper
            //services.AddScoped<ITodoService>(impl => new MTech.DapperSample.TodoService(new SqlConnection(connectionString)));

            services.AddScoped<IAnimalService>(implementationFactory => new MTech.DapperSample.AnimalService(new SqlConnection(animalFarmConnectionString)));
            // EFCore
            //services.AddDbContext<MTech.EFSample.TodoContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});
            //
            //services.AddScoped<ITodoService, MTech.EFSample.TodoService>();

            //services.AddDbContext<MTech.EFSample.AnimalContext>(options =>
            //{
            //    options.UseSqlServer(animalFarmConnectionString);
            //});
            //
            //services.AddScoped<IAnimalService, MTech.EFSample.AnimalService>();

            // Linq2Db
            //services.AddLinqToDbContext<MTech.LinqToDBSample.TodoDataConnection>((provider, options) =>
            //{
            //    options.UseSqlServer(connectionString);
            //});
            //services.AddScoped<ITodoService, MTech.LinqToDBSample.TodoService>();

            // NHibernate
            //services.AddNHibernate(connectionString);
            //services.AddScoped<ITodoService, MTech.NHibernateSample.TodoService>();

            // LLBLGen
            RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", connectionString);
            RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
                                c => c.SetTraceLevel(TraceLevel.Verbose)
                                        .AddDbProviderFactory(typeof(System.Data.SqlClient.SqlClientFactory))
                                        .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));

            services.AddScoped<ITodoService, MTech.LLBLGenSample.TodoService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}