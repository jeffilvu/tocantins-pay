namespace TocantinsPay.Core.Models.InputModels
{
    public class DepositoInputModel(decimal valor, string descricao, Guid carteiraId)
    {
        public decimal Valor { get; } = valor;
        public string Descricao { get; } = descricao;
        public Guid CarteiraId { get; } = carteiraId;
    }
}
