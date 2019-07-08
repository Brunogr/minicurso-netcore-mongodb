using Microsoft.Extensions.DependencyInjection;
using Minicurso.NetCore.MongoDB.Infra.Data;
using Minicurso.NetCore.MongoDB.Infra.Data.Configuration;
using Minicurso.NetCore.MongoDB.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, 
            Func<DatabaseConfiguration, DatabaseConfiguration> configurationFunc)
        {
            DatabaseConfiguration configuration = new DatabaseConfiguration();
            configurationFunc(configuration);

            services.AddSingleton(configuration);
            services.AddScoped<IDbConnection, DbConnection>();
            services.AddScoped<IComandaRepository, ComandaRepository>();
            return services;
        }
    }
}
