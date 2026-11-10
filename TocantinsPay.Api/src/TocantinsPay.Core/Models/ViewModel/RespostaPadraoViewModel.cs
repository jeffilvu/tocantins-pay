namespace TocantinsPay.Core.Models.ViewModel
{
    public class RespostaPadraoViewModel(IEnumerable<string> mensagens)
    {
        public IEnumerable<string> Mensagens { get; } = mensagens;
    }
}
