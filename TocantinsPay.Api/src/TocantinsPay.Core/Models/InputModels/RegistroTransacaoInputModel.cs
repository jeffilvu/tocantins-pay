using TocantinsPay.Core.Enums;

namespace TocantinsPay.Core.Models.InputModels
{
    public class RegistroTransacaoInputModel(ETipoTransacao tipoTransacao, decimal valor, string descricao, Guid carteiraId, decimal saldoResultante, Guid? cofrinhoId = null)
    {
        public ETipoTransacao TipoTransacao { get; } = tipoTransacao;
        public decimal Valor { get; } = valor;
        public string Descricao { get; } = descricao;
        public Guid CarteiraId { get; } = carteiraId;
        public decimal SaldoResultante { get; } = saldoResultante;
        public Guid? CofrinhoId { get; } = cofrinhoId;
    }
}
