using TocantinsPay.Core.Entities;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Mappers
{
    public static class TransacaoMapper
    {
        public static Transacao ToEntity(this RegistroTransacaoInputModel inputModel)
        {
            return new Transacao(
                inputModel.TipoTransacao,
                inputModel.Valor,
                inputModel.Descricao,
                inputModel.CarteiraId,
                inputModel.SaldoResultante,
                inputModel.CofrinhoId
            );
        }
    }
}
