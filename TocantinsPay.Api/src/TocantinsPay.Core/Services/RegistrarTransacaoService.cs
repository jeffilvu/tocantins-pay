using TocantinsPay.Core.Interfaces.Repositories;
using TocantinsPay.Core.Interfaces.Services;
using TocantinsPay.Core.Mappers;
using TocantinsPay.Core.Models.InputModels;

namespace TocantinsPay.Core.Services
{
    public class RegistrarTransacaoService(IUnitOfWork unitOfWork) : IRegistrarTransacaoService
    {
        public async Task<Guid> RegistrarAsync(RegistroTransacaoInputModel inputModel)
        {
            return await unitOfWork.Transacoes.CadastrarAsync(inputModel.ToEntity());
        }
    }
}
