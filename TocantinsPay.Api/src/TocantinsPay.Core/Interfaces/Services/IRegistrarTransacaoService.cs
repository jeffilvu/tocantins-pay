using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Interfaces.Services
{
    public interface IRegistrarTransacaoService
    {
        Task<Guid> RegistrarAsync(RegistroTransacaoInputModel inputModel);
    }
}
