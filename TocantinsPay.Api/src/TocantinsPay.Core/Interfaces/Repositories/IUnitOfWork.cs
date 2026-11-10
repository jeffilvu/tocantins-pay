namespace TocantinsPay.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        ICarteiraRepository Carteiras { get; }
        ITransacaoRepository Transacoes { get; }
        Task BeginTransactionAsync();
        Task SaveChangesAsync();
        Task CommitAsync();
    }
}
