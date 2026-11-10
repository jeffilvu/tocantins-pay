using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Interfaces.Applications
{
    public interface IDebitarApplication
    {
        Task<decimal> DebitarAsync(DebitoInputModel inputModel);
    }
}
