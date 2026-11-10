using Microsoft.AspNetCore.Mvc;
using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Notifications;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Api.Controllers
{
    public class TransacaoController(
        IDepositarApplication depositarApplication,
        IDebitarApplication debitarApplication,
        INotifier notifier
    ) : MainController(notifier)
    {
        [HttpPost("deposito")]
        public async Task<IActionResult> DepositarAsync([FromBody] DepositoInputModel inputModel)
        {
            var saldoResultante = await depositarApplication.DepositarAsync(inputModel);

            return RespostaPersonalizada(Ok(saldoResultante));
        }

        [HttpPost("debito")]
        public async Task<IActionResult> DebitarAsync([FromBody] DebitoInputModel inputModel)
        {
            var saldoResultante = await debitarApplication.DebitarAsync(inputModel);

            return RespostaPersonalizada(Ok(saldoResultante));
        }
    }
}
