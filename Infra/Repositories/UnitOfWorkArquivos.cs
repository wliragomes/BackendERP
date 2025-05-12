using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UnitOfWorkArquivos : IUnitOfWorkArquivos
    {
        private readonly CratosArquivosDbContext _context;

        public UnitOfWorkArquivos(CratosArquivosDbContext context)
        {
            _context = context;
        }

        private OrdemFabricacaoArquivoRepository _ordemFabricacaoArquivoRepository;

        public IOrdemFabricacaoArquivoRepository OrdemFabricacaoArquivoRepository
        {
            get
            {
                return _ordemFabricacaoArquivoRepository = _ordemFabricacaoArquivoRepository ?? new OrdemFabricacaoArquivoRepository(_context);
            }
        }

        void IUnitOfWorkArquivos.Commit()
        {
            _context.SaveChanges();
        }

        bool IUnitOfWorkArquivos.NewCommit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task RollbackAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync();
                        break;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }

}
