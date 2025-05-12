using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class OrdemFabricacaoRepository : IOrdemFabricacaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public OrdemFabricacaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(OrdemFabricacao ordemFabricacao)
        {
            await _contexto.OrdemFabricacao.AddAsync(ordemFabricacao);
        }

        public async Task<OrdemFabricacao?> ObterPorId(Guid? id)
        {
            return await _contexto.OrdemFabricacao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.OrdemFabricacao.AnyAsync(x => x.Id == id);
        }

        public async Task AdicionarEmMassa(List<OrdemFabricacao> ordensFabricacoes, CancellationToken cancellationToken = default)
        {
            await _contexto.OrdemFabricacao.AddRangeAsync(ordensFabricacoes, cancellationToken);
        }

        public async Task<List<OrdemFabricacao>> RetornarOrdensFabricacoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.OrdemFabricacao;
            var query = FiltroBuilder<OrdemFabricacao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<int> ObterUltimoSqOrdemFabricacaoCodigo()
        {
            return await _contexto.OrdemFabricacao
                .MaxAsync(r => (int?)r.SqOrdemFabricacaoCodigo) ?? 0; // Retorna o maior número ou 0 se não houver registros
        }
    }
}