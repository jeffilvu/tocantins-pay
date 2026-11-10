namespace TocantinsPay.Core.Models.ViewModel
{
    public class ClienteViewModel
    {
        public ClienteViewModel(Guid id, Guid carteiraId, string nomeCompleto, DateOnly dataNascimento)
        {
            Id = id;
            CarteiraId = carteiraId;
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
        }

        public Guid Id { get; }
        public Guid CarteiraId { get; }
        public string NomeCompleto { get; }
        public DateOnly DataNascimento { get; }

    }
}
