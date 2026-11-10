using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Interfaces.Applications
{
    public interface ICadastrarClienteApplication
    {
        Task<Guid> CadastrarAsync(ClienteInputModel inputModel);
    }
}
