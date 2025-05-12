namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkArquivos
    {
        IOrdemFabricacaoArquivoRepository OrdemFabricacaoArquivoRepository { get; }

        void Commit();

        bool NewCommit();

        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync();

        Task DisposeAsync();
    }
}
