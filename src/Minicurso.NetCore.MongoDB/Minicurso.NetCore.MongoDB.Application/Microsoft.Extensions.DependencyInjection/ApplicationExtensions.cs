using Microsoft.Extensions.DependencyInjection;
using Minicurso.NetCore.MongoDB.Application;
using Minicurso.NetCore.MongoDB.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IComandaService, ComandaService>();

            return services;
        }
    }
}
