using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Interfaces.Applications
{
    public interface IDepositarApplication
    {
        Task<decimal> DepositarAsync(DepositoInputModel inputModel);
    }
}
