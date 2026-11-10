using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Core.Interfaces.Applications
{
    public interface IBuscarClientesApplication
    {
        Task<IEnumerable<ClienteViewModel>> BuscarAsync();
    }
}
