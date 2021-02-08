using Microsoft.Extensions.DependencyInjection;
using MovimentosManuais.Application.Presenters;
using MovimentosManuais.Core;
using MovimentosManuais.Core.Api;
using MovimentosManuais.Core.Factories;
using MovimentosManuais.Core.Services;
using MovimentosManuais.Persistence.Api;
using MovimentosManuais.Persistence.Repositories;

namespace MovimentosManuais.IoC
{
    public class NativeInjectorBootStrapper
    {
        private static IServiceCollection _services;

        public static void RegisterServices(IServiceCollection services)
        {
            _services = services;

            // Application
            services.AddScoped<IProductPresenter, ProductPresenter>();
            services.AddScoped<ICosifProductPresenter, CosifProductPresenter>();
            services.AddScoped<IManualMovementPresenter, ManualMovementPresenter>();

            //repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICosifProductRepository, CosifProductRepository>();
            services.AddScoped<IManualMovementRepository, ManualMovementRepository>();

            //service
            services.AddScoped<IManualMovementService, ManualMovementService>();

            //Factories
            services.AddScoped<IDateLaunchNumberFactory, DateLaunchNumberFactory>();
        }
    }
}
