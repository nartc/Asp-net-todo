using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using Task.Models;
using Task.Persistence;
using Task.Repositories;
using Task.Services;
using AutoMapper;

namespace Task
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
            services.AddMvc();
            services.Configure<MongoOptions>(Configuration.GetSection("Mongo"));
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddTransient<ITodoService, TodoService>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            BsonClassMap.RegisterClassMap<Todo>();
            app.UseMvc();
        }
    }
}