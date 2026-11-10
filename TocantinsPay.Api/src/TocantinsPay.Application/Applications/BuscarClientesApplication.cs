using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Application.Applications
{
    public class BuscarClientesApplication(
        IClienteRepository clienteRepository,
        ICarteiraRepository carteiraRepository
    ) : IBuscarClientesApplication
    {
        public async Task<IEnumerable<ClienteViewModel>> BuscarAsync()
        {
            var clientes = await clienteRepository.BuscarAsync();

            var viewModels = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                var carteira = await carteiraRepository.BuscarPorClienteIdAsync(cliente.Id);

                if (carteira is not null)
                {
                    viewModels.Add(new ClienteViewModel(
                        cliente.Id,
                        carteira.Id,
                        cliente.NomeCompleto,
                        cliente.DataNascimento
                    ));
                }
            }

            return viewModels;
        }
    }
}
