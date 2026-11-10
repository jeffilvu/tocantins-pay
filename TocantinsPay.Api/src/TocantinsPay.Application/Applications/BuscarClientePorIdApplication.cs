using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Mappers;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Application.Applications
{
    public class BuscarClientePorIdApplication(IClienteRepository clienteRepository) : IBuscarClientePorIdApplication
    {
        public async Task<ClienteViewModel?> BuscarPorIdAsync(Guid id)
        {
            var cliente = await clienteRepository.BuscarPorIdAsync(id);

            return cliente?.ToViewModel();
        }
    }
}
