using TocantinsPay.Core.Enums;

namespace TocantinsPay.Core.Models.InputModels
{
    public class DebitoInputModel(ETipoTransacao tipo, decimal valor, string descricao, Guid carteiraId)
    {
        public ETipoTransacao Tipo { get; } = tipo;
        public decimal Valor { get; } = valor;
        public string Descricao { get; } = descricao;
        public Guid CarteiraId { get; } = carteiraId;
    }
}
