using System.Net;

namespace TocantinsPay.Core.Models.ViewModel
{
    public class NotificacaoViewModel(string mensagem, HttpStatusCode statusCode)
    {
        public string Mensagem { get; } = mensagem;
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}
