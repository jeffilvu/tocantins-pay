using Microsoft.AspNetCore.Mvc;
using TocantinsPay.Core.Interfaces.Notifications;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController(INotifier notifier) : ControllerBase
    {
        protected readonly INotifier _notifier = notifier;

        protected ActionResult RespostaPersonalizada(ActionResult actionResult)
        {
            if (OperacaoValida())
                return actionResult;

            var notificacoes = _notifier.ObterNotificacoes();

            return new JsonResult(new RespostaPadraoViewModel(notificacoes.Select(n => n.Mensagem)))
            {
                StatusCode = (int)notificacoes[0].StatusCode
            };
        }

        private bool OperacaoValida() => !_notifier.TemNotificacoes();
    }
}
