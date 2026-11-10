using TocantinsPay.Core.Entities;
using TocantinsPay.Core.Interfaces.Repositories;

namespace TocantinsPay.Infrastructure.Repositories
{
    public class TransacaoRepository(TocantinsPayContext dbContext) : ITransacaoRepository
    {
        public async Task<Guid> CadastrarAsync(Transacao transacao)
        {
            var entidade = await dbContext.Transacoes.AddAsync(transacao);

            await dbContext.SaveChangesAsync();

            return entidade.Entity.Id;
        }
    }
}
