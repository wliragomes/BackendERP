using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class ClassificacaoRepository : IClassificacaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public ClassificacaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Classificacao classificacao)
        {
            await _contexto.Classificacao.AddAsync(classificacao);
        }

        public async Task<Classificacao?> ObterPorId(Guid? id)
        {
            return await _contexto.Classificacao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Classificacao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteNomeAsync(string nome, Guid? id)
        {
            return await _contexto.Classificacao.AnyAsync(x => x.Nome == nome && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Classificacao> classificacoes, CancellationToken cancellationToken = default)
        {
            await _contexto.Classificacao.AddRangeAsync(classificacoes, cancellationToken);
        }

        public async Task<List<Classificacao>> RetornarClassificacoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Classificacao;
            var query = FiltroBuilder<Classificacao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}