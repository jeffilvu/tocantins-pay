using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Core.Interfaces.Applications
{
    public interface IBuscarClientePorIdApplication
    {
        Task<ClienteViewModel?> BuscarPorIdAsync(Guid id);
    }
}
