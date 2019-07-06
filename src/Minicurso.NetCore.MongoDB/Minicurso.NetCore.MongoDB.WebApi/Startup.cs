using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minicurso.NetCore.MongoDB.Application;
using Minicurso.NetCore.MongoDB.Application.Interface;
using Minicurso.NetCore.MongoDB.Infra.Data;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace Minicurso.NetCore.MongoDB.WebApi
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Minicurso Escola de Férias",
                    Description = "Web Api em Aspnet core 2.0 e MongoDB",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Bruno Gouvêa Roldão",
                        Email = "Brunogrbhg@gmail.com",
                        Url = "https://github.com/Brunogr"
                    }
                });
            });

            services.AddMvc();

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }

        public void RegisterServices(IServiceCollection services)
        {
        }
    }
}
