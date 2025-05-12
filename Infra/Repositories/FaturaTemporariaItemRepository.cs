using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utils;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using SharedKernel.Data;
using SharedKernel.SharedObjects;

namespace Infra.Repositories
{
    public class FaturaTemporariaItemRepository : IFaturaTemporariaItemRepository
    {
        private readonly ApplicationDbContext _contexto;

        public FaturaTemporariaItemRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task Adicionar(FaturaTemporariaItem faturaTemporariaItem)
        {
            await _contexto.FaturaTemporariaItem.AddAsync(faturaTemporariaItem);
        }

        public async Task RemoverMassa(List<FaturaTemporariaItem> faturaTemporariaItem, CancellationToken cancellationToken = default)
        {
            _contexto.FaturaTemporariaItem.RemoveRange(faturaTemporariaItem);
        }

        public async Task<List<FaturaTemporariaItem>> ObterPorIdFaturaTemporariaItem(Guid? id)
        {
            return await _contexto.FaturaTemporariaItem
                                  .Where(x => x.IdFaturaTemporaria == id)
                                  .ToListAsync();
        }

        public async Task<FaturaTemporariaItem?> ObterPorId(Guid? id)
        {
            return await _contexto.FaturaTemporariaItem
                .FirstOrDefaultAsync(p => p.IdFaturaTemporaria == id);
        }

        public async Task<FaturaTemporariaItem?> ObterFaturaTemporariaItemPorId(Guid? idFaturaTemporaria, int SqItem)
        {
            return await _contexto.FaturaTemporariaItem
                .FirstOrDefaultAsync(p => p.IdFaturaTemporaria == idFaturaTemporaria && p.SqItem == SqItem);
        }

        public async Task<bool> ExisteIdAsync(Guid? id)
        {
            return await _contexto.FaturaTemporariaItem.AnyAsync(x => x.IdFaturaTemporaria == id);
        }

        public async Task AdicionarEmMassa(List<FaturaTemporariaItem> ordensFabricacoesItem, CancellationToken cancellationToken = default)
        {
            await _contexto.FaturaTemporariaItem.AddRangeAsync(ordensFabricacoesItem, cancellationToken);
        }

        public async Task<List<FaturaTemporariaItem>> RetornarOrdensFabricacoesItemExcluirMassa(FiltroBase filtroBase)
        {
            var dbSetQuery = _contexto.FaturaTemporariaItem;
            var query = FiltroBuilder<FaturaTemporariaItem>.ConstruirQuery(dbSetQuery, filtroBase);
            return await query.ToListAsync();
        }

        public async Task<List<ResultadoCalculoImpostoDto>> CalcularImpostosFaturaTemporariaAsync(Guid idFaturaTemporaria)
        {
            string query = @"
                EXEC dbo.PR_CALCULA_IMPOSTOS_NFE 
                    @CD_CODIGO = @IdFaturaTemporaria, 
                    @FL_RETORNO = 'F',
                    @APAGA = true";

            using var connection = _contexto.Database.GetDbConnection();
            return await connection.RetornarListDapper<ResultadoCalculoImpostoDto>(query, new
            {
                IdFaturaTemporaria = idFaturaTemporaria
            });
        }
    }
}
