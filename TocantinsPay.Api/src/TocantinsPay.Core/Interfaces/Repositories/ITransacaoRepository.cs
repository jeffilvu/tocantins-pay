using TocantinsPay.Core.Entities;

namespace TocantinsPay.Core.Interfaces.Repositories
{
    public interface ITransacaoRepository
    {
        public Task<Guid> CadastrarAsync(Transacao transacao); 
    }
}
