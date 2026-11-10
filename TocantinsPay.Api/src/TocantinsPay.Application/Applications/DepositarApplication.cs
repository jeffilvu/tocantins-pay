using System.Net;
using TocantinsPay.Core.Enums;
using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Notifications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Interfaces.Services;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Applications
{
    public class DepositarApplication(
        IUnitOfWork unitOfWork,
        IRegistrarTransacaoService registrarTransacaoService,
        INotifier notifier
    ) : IDepositarApplication
    {
        public async Task<decimal> DepositarAsync(DepositoInputModel inputModel)
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

            var saldoResultante = carteira.Saldo + inputModel.Valor;

            var transacao = new RegistroTransacaoInputModel(
                ETipoTransacao.Deposito,
                inputModel.Valor,
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
