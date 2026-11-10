using Microsoft.Extensions.DependencyInjection;
using TocantinsPay.Application.Applications;
using TocantinsPay.Application.Notifications;
using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Notifications;

namespace TocantinsPay.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastrarClienteApplication, CadastrarClienteApplication>();
            services.AddScoped<IBuscarClientesApplication, BuscarClientesApplication>();
            services.AddScoped<IBuscarClientePorIdApplication, BuscarClientePorIdApplication>();
            services.AddScoped<IAtualizarClienteApplication, AtualizarClienteApplication>();
            services.AddScoped<IDepositarApplication, DepositarApplication>();
            services.AddScoped<IDebitarApplication, DebitarApplication>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
