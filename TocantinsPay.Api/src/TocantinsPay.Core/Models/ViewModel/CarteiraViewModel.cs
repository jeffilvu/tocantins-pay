namespace TocantinsPay.Core.Models.ViewModel
{
    public class CarteiraViewModel
    {
        public CarteiraViewModel(Guid id, Guid clienteId, decimal saldo, string conta, string agencia)
        {
            Id = id;
            ClienteId = clienteId;
            Saldo = saldo;
            Conta = conta;
            Agencia = agencia;
        }

        public Guid Id { get; }
        public Guid ClienteId { get; }
        public decimal Saldo { get; }
        public string Conta { get; }
        public string Agencia { get; }
    }
}
