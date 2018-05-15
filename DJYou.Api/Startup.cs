using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DJYou.Data;
using DJYou.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DJYouAPI
{
    public class Startup
    {
        private const string API_VERSION = "v1";
        private const string CORS_POLICY = "policy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new Info
                {
                    Version = API_VERSION,
                    Title = "DJ You Api"
                });
            });

            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddSingleton<Random>();

            services.AddCors(o => o.AddPolicy(CORS_POLICY, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            var connection = @"Server=localhost\SQLEXPRESS;Database=DJYou;Trusted_Connection=True;";
            services.AddDbContext<DJYouContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CORS_POLICY);
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{API_VERSION}/swagger.json", $"DJ You Api {API_VERSION}");
            });
        }
    }
}
