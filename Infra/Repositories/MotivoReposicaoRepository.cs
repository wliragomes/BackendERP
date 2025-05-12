using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class MotivoReposicaoRepository : IMotivoReposicaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public MotivoReposicaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(MotivoReposicao motivoReposicao)
        {
            await _contexto.MotivoReposicao.AddAsync(motivoReposicao);
        }

        public async Task<MotivoReposicao?> ObterPorId(Guid? id)
        {
            return await _contexto.MotivoReposicao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.MotivoReposicao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExisteDescricaoAsync(string descricao, Guid? id)
        {
            return await _contexto.MotivoReposicao.AnyAsync(x => x.Descricao == descricao && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<MotivoReposicao> motivoReposicaos, CancellationToken cancellationToken = default)
        {
            await _contexto.MotivoReposicao.AddRangeAsync(motivoReposicaos, cancellationToken);
        }

        public async Task<List<MotivoReposicao>> RetornarMotivoReposicaosExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.MotivoReposicao;
            var query = FiltroBuilder<MotivoReposicao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}