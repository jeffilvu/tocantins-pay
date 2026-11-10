using System.Net;
using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Notifications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Interfaces.Services;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Applications
{
    public class DebitarApplication(
        IUnitOfWork unitOfWork,
        IRegistrarTransacaoService registrarTransacaoService,
        INotifier notifier
    ) : IDebitarApplication
    {
        public async Task<decimal> DebitarAsync(DebitoInputModel inputModel)
        {
            var carteira = await unitOfWork.Carteiras.BuscarPorIdAsync(inputModel.CarteiraId);

            if (carteira is null)
            {
                notifier.Handle(
                    @$"Não foi encontrada nenhuma carteira com o id ""{inputModel.CarteiraId}"".",
                    HttpStatusCode.NotFound
                );

                return 0m;
            }

            var valorAbsolutoDebito = Math.Abs(inputModel.Valor);

            if (valorAbsolutoDebito > carteira.Saldo)
            {
                notifier.Handle(
                    $"Esta operação não pode ser realizada, saldo insuficiente! Saldo atual: R$ {carteira.Saldo}",
                    HttpStatusCode.BadRequest
                );

                return 0m;
            }

            var saldoResultante = carteira.Saldo - valorAbsolutoDebito;

            var transacao = new RegistroTransacaoInputModel(
                inputModel.Tipo,
                valorAbsolutoDebito * -1,
                inputModel.Descricao,
                inputModel.CarteiraId,
                saldoResultante
            );

            try
            {
                await unitOfWork.BeginTransactionAsync();

                await registrarTransacaoService.RegistrarAsync(transacao);

                carteira.AtualizarSaldo(saldoResultante);

                await unitOfWork.SaveChangesAsync();

                await unitOfWork.CommitAsync();

                return saldoResultante;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
