using TocantinsPay.Core.Entities;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Core.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteViewModel ToViewModel(this Cliente cliente)
        {
            return new ClienteViewModel(
                cliente.Id,
                Guid.Empty,
                cliente.NomeCompleto,
                cliente.DataNascimento
            );
        }
    }
}
