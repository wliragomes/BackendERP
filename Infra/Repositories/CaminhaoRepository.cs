using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public CaminhaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(Caminhao caminhao)
        {
            await _contexto.Caminhao.AddAsync(caminhao);
        }

        public async Task<Caminhao?> ObterPorId(Guid? id)
        {
            return await _contexto.Caminhao.FindAsync(id);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.Caminhao.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistePlacaAsync(string placa, Guid? id)
        {
            return await _contexto.Caminhao.AnyAsync(x => x.Placa == placa && x.Id != id);
        }

        public async Task AdicionarEmMassa(List<Caminhao> caminhoes, CancellationToken cancellationToken = default)
        {
            await _contexto.Caminhao.AddRangeAsync(caminhoes, cancellationToken);
        }

        public async Task<List<Caminhao>> RetornarCaminhoesExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.Caminhao;
            var query = FiltroBuilder<Caminhao>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }
    }
}