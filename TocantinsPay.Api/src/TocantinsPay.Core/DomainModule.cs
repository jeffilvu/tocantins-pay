using Microsoft.Extensions.DependencyInjection;
using TocantinsPay.Core.Interfaces.Services;
using TocantinsPay.Core.Services;

namespace TocantinsPay.Core
{
    public static class DomainModule
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IRegistrarTransacaoService, RegistrarTransacaoService>();

            return services;
        }
    }
}
