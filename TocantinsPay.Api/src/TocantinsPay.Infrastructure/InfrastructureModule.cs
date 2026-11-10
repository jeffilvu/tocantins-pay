using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Infrastructure.Repositories;

namespace TocantinsPay.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<TocantinsPayContext>(p => p.UseNpgsql("Server=localhost;Port=5490;Database=tocantinspay;User Id=admin;Password=admin;"));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICarteiraRepository, CarteiraRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
