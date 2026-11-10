using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Interfaces.Applications
{
    public interface IAtualizarClienteApplication
    {
        Task AtualizarAsync(Guid id, AtualizacaoClienteInputModel inputModel);
    }
}
