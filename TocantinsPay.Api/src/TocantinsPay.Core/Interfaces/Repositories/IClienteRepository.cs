using TocantinsPay.Core.Entities;

namespace TocantinsPay.Core.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<Guid> CadastrarAsync(Cliente cliente);

        Task<IEnumerable<Cliente>> BuscarAsync();

        Task<Cliente?> BuscarPorIdAsync(Guid id);

        Task SaveChangesAsync();
    }
}
