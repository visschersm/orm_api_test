using LinqToDB.AspNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MTech;
using MTech.NHibernateSample;
using MTech.NHibernateSample.Mapping;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TestApi
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
            var todoListConnectionString = Configuration.GetConnectionString("TodoList");
            var animalFarmConnectionString = Configuration.GetConnectionString("AnimalFarm");

            switch (Environment.GetEnvironmentVariable("ORM"))
            {
                case "Dapper":
                    services.AddScoped<IWeatherService>(impl => new MTech.DapperSample.WeatherService(new SqlConnection(connectionString)));
                    services.AddScoped<ITodoService>(impl => new MTech.DapperSample.TodoService(new SqlConnection(todoListConnectionString)));
                    services.AddScoped<IAnimalService>(implementationFactory => new MTech.DapperSample.AnimalService(new SqlConnection(animalFarmConnectionString)));
                    break;
                case "EFCore":

                    services.AddDbContext<MTech.EFSample.WeatherContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });

                    services.AddScoped<IWeatherService, MTech.EFSample.WeatherService>();

                    services.AddDbContext<MTech.EFSample.TodoContext>(options =>
                    {
                        options.UseSqlServer(todoListConnectionString);
                    });
                    services.AddScoped<ITodoService, MTech.EFSample.TodoService>();

                    services.AddDbContext<MTech.EFSample.AnimalContext>(options =>
                    {
                        options.UseSqlServer(animalFarmConnectionString);
                    });
                    services.AddScoped<IAnimalService, MTech.EFSample.AnimalService>();
                    break;
                case "Linq2Db":
                    services.AddLinqToDbContext<MTech.LinqToDBSample.WeatherConnection>((provider, options) =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                    services.AddScoped<IWeatherService, MTech.LinqToDBSample.WeatherService>();

                    services.AddLinqToDbContext<MTech.LinqToDBSample.TodoDataConnection>((provider, options) =>
                    {
                        options.UseSqlServer(todoListConnectionString);
                    });
                    services.AddScoped<ITodoService, MTech.LinqToDBSample.TodoService>();

                    services.AddLinqToDbContext<MTech.LinqToDBSample.AnimalConnection>((provider, options) =>
                    {
                        options.UseSqlServer(animalFarmConnectionString);
                    });
                    services.AddScoped<IAnimalService, MTech.LinqToDBSample.AnimalService>();
                    break;
                case "LLBLGen":
                    RuntimeConfiguration.AddConnectionString("WeatherContext", connectionString);
                    RuntimeConfiguration.AddConnectionString("TodoContext", todoListConnectionString);
                    RuntimeConfiguration.AddConnectionString("AnimalContext", animalFarmConnectionString);
                    RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(
                                        c => c.SetTraceLevel(TraceLevel.Verbose)
                                                .AddDbProviderFactory(typeof(System.Data.SqlClient.SqlClientFactory))
                                                .SetDefaultCompatibilityLevel(SqlServerCompatibilityLevel.SqlServer2012));

                    services.AddScoped<IWeatherService, MTech.LLBLGenSample.WeatherService>();
                    services.AddScoped<ITodoService, MTech.LLBLGenSample.TodoService>();
                    services.AddScoped<IAnimalService, MTech.LLBLGenSample.AnimalService>();
                    break;
                case "NHibernate":
                    services.AddNHibernate(connectionString, typeof(WeatherMapping));
                    services.AddNHibernate(todoListConnectionString, typeof(TodoItemMapping));
                    services.AddNHibernate(animalFarmConnectionString,
                        typeof(AnimalMapping),
                        typeof(DogMapping),
                        typeof(CowMapping));
                    services.AddScoped<IWeatherService, MTech.NHibernateSample.WeatherService>();
                    services.AddScoped<ITodoService, MTech.NHibernateSample.TodoService>();
                    services.AddScoped<IAnimalService, MTech.NHibernateSample.AnimalService>();
                    break;
            }

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
