using TocantinsPay.Core.Entities;
using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Applications
{
    public class CadastrarClienteApplication(
        IUnitOfWork unitOfWork
    ) : ICadastrarClienteApplication
    {
        public async Task<Guid> CadastrarAsync(ClienteInputModel inputModel)
        {
            var cliente = new Cliente(
                inputModel.NomeCompleto,
                inputModel.Email,
                inputModel.Cpf,
                inputModel.DataNascimento,
                inputModel.Telefone,
                inputModel.Senha
            );

            try
            {
                await unitOfWork.BeginTransactionAsync();

                var clienteId = await unitOfWork.Clientes.CadastrarAsync(cliente);

                var carteira = new Carteira(clienteId);

                await unitOfWork.Carteiras.CadastrarAsync(carteira);

                await unitOfWork.CommitAsync();

                return clienteId;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
