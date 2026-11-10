using Microsoft.EntityFrameworkCore;
using TocantinsPay.Core.Entities;
using TocantinsPay.Core.Interfaces.Repositories;

namespace TocantinsPay.Infrastructure.Repositories
{
    public class ClienteRepository(TocantinsPayContext dbContext) : IClienteRepository
    {
        public async Task<Guid> CadastrarAsync(Cliente cliente)
        {
            var entidade = await dbContext.Clientes.AddAsync(cliente);

            await dbContext.SaveChangesAsync();

            return entidade.Entity.Id;
        }

        public async Task<IEnumerable<Cliente>> BuscarAsync()
        {
            var clientes = await dbContext.Clientes.ToListAsync();

            return clientes;
        }

        public async Task<Cliente?> BuscarPorIdAsync(Guid id)
        {
            var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            return cliente;
        }

        public Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
