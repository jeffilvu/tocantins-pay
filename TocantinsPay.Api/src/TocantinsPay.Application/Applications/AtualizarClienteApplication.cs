using TocantinsPay.Core.Interfaces.Applications;
using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Application.Applications
{
    public class AtualizarClienteApplication(
        IClienteRepository clienteRepository
    ) : IAtualizarClienteApplication
    {
        public async Task AtualizarAsync(Guid id, AtualizacaoClienteInputModel inputModel)
        {
            var cliente = await clienteRepository.BuscarPorIdAsync(id);

            if (cliente == null)
                throw new NullReferenceException("O cliente informado não foi encontrado na base");

            cliente
                .SetNomeCompleto(inputModel.NomeCompleto)
                .SetEmail(inputModel.Email)
                .SetTelefone(inputModel.Telefone);

            await clienteRepository.SaveChangesAsync();
        }
    }
}
