using System.Net;
using TocantinsPay.Core.Models.ViewModel;

namespace TocantinsPay.Core.Interfaces.Notifications
{
    public interface INotifier
    {
        void LimparNotificacoes();
        bool TemNotificacoes();
        List<NotificacaoViewModel> ObterNotificacoes();
        void Handle(string mensagem, HttpStatusCode statusCode);
    }
}
