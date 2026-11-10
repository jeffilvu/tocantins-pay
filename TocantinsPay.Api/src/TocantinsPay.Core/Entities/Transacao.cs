using TocantinsPay.Core.Enums;
using TocantinsPay.Core.Utils;

namespace TocantinsPay.Core.Entities;

public class Transacao
{
    public Transacao()
    {
        
    }

    public Transacao(ETipoTransacao tipo, decimal valor, string? descricao, Guid carteiraId, decimal saldoResultante, Guid? cofrinhoId = null)
    {
        Id = Guid.NewGuid();
        Tipo = (short)tipo;
        Data = DateAndTimeUtils.Now();
        Valor = valor;
        SaldoResultante = saldoResultante;
        Descricao = descricao;
        CarteiraId = carteiraId;
        CofrinhoId = cofrinhoId;
    }

    public Guid Id { get; }

    public short Tipo { get; }

    public DateTime Data { get; }

    public decimal Valor { get; }

    public decimal SaldoResultante { get; }

    public string? Descricao { get; }

    public Guid CarteiraId { get; }

    public Guid? CofrinhoId { get; }
}
