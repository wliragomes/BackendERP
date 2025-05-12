using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CodigoImportacaoRepository : ICodigoImportacaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CodigoImportacaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(CodigoImportacao codigo)
        {
            await _contexto.CodigoImportacao.AddAsync(codigo);
        }

        public async Task<CodigoImportacao?> ObterPorId(Guid? id)
        {
            return await _contexto.CodigoImportacao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.CodigoImportacao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string descricao, Guid? id)
        {
            return await _contexto.CodigoImportacao.AnyAsync(x => x.Nome == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<CodigoImportacao> codigo, CancellationToken cancellationToken = default)
        {
            await _contexto.CodigoImportacao.AddRangeAsync(codigo, cancellationToken);
        }

        public async Task<List<CodigoImportacao>> RetornarCodigoImportacaoExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.CodigoImportacao;
            var query = FiltroBuilder<CodigoImportacao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

    }
}
