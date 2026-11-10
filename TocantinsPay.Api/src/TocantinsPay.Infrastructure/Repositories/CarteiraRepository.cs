using Microsoft.EntityFrameworkCore;
using TocantinsPay.Core.Entities;
using TocantinsPay.Core.Interfaces.Repositories;

namespace TocantinsPay.Infrastructure.Repositories
{
    public class CarteiraRepository(TocantinsPayContext dbContext) : ICarteiraRepository
    {
        public async Task<Guid> CadastrarAsync(Carteira carteira)
        {
            var entidade = await dbContext.Carteiras.AddAsync(carteira);

            await dbContext.SaveChangesAsync();

            return entidade.Entity.Id;
        }

        public async Task<Carteira?> BuscarPorIdAsync(Guid carteiraId)
        {
            return await dbContext.Carteiras.FirstOrDefaultAsync(c => c.Id == carteiraId);
        }

        public async Task<Carteira?> BuscarPorClienteIdAsync(Guid clienteId)
        {
            return await dbContext.Carteiras.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }
    }
}
