using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovimentosManuais.Libraries;
using System;

namespace MovimentosManuais.API.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient((sp) => CreateDataContext(connectionString));
        }

        private static IDataContext CreateDataContext(string connectionString)
        {
            return new DataContextFactory().CreateDataContext(connectionString);
        }
    }
}
