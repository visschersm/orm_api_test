using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MTech;
using MTech.NHibernateSample;
using System.Data.SqlClient;

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
            services.AddScoped<IWeatherService>(impl => new MTech.DapperSample.WeatherService(new SqlConnection(connectionString)));

            connectionString = Configuration.GetConnectionString("TodoList");
            // Dapper
            //services.AddScoped<ITodoService>(impl => new MTech.DapperSample.TodoService(new SqlConnection(connectionString)));

            // EFCore
            //services.AddDbContext<MTech.EFSample.TodoContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});
            //
            //services.AddScoped<ITodoService, MTech.EFSample.TodoService>();

            // Linq2Db
            //services.AddLinqToDbContext<MTech.LinqToDBSample.TodoDataConnection>((provider, options) =>
            //{
            //    options.UseSqlServer(connectionString);
            //});
            //services.AddScoped<ITodoService, MTech.LinqToDBSample.TodoService>();

            // NHibernate
            services.AddNHibernate(connectionString);
            services.AddScoped<ITodoService, MTech.NHibernateSample.TodoService>();

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
