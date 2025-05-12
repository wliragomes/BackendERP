using Application.Interfaces.Queries;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.FaturaTemporarias;

namespace Infra.Queries.OrdensFabricacoes
{
    public class FaturaTemporariaQuery : IFaturaTemporariaQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public FaturaTemporariaQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FaturaTemporariaByCodeDto?> RetornarPorId(Guid id)
        {
            var FaturaTemporaria = await _dbContext.FaturaTemporaria
                .Include(s => s.FaturaTemporariaItem)
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (FaturaTemporaria != null)
            {
                return new FaturaTemporariaByCodeDto
                {
                    Id = FaturaTemporaria.Id,
                    IdEmpresa = FaturaTemporaria.IdEmpresa,
                    IdPessoa = FaturaTemporaria.IdPessoa,
                    //IdTipoConsumidor = FaturaTemporaria.IdTipoConsumidor,
                    ValorFrete = FaturaTemporaria.ValorFrete,
                    ValorSeguro = FaturaTemporaria.ValorSeguro,
                    ValorOutrasDespesas = FaturaTemporaria.ValorOutrasDespesas,
                    PrIcms = FaturaTemporaria.PrIcms,
                    ValorIcms = FaturaTemporaria.ValorIcms,
                    ValorPis = FaturaTemporaria.ValorPis,
                    ValorIpi = FaturaTemporaria.ValorIpi,
                    ValorCofins = FaturaTemporaria.ValorCofins,
                    BaseCalculoSt = FaturaTemporaria.BaseCalculoSt,
                    ValorSt = FaturaTemporaria.ValorSt,
                    ValorTotalProduto = FaturaTemporaria.ValorTotalProduto,
                    ValorTotalNota = FaturaTemporaria.ValorTotalNota,
                    FaturaTemporariaItem = FaturaTemporaria.FaturaTemporariaItem!.Select(item => new FaturaTemporariaItemDto
                    {
                        IdFaturaTemporaria = item.IdFaturaTemporaria,
                        SqItem = item.SqItem,
                        IdProduto = item.IdProduto,
                        QtdProduto = item.QtdProduto,
                        ValorUnitarioProduto = item.ValorUnitarioProduto,
                        ValorTotalProduto = item.ValorTotalProduto,
                        IdCfop = item.IdCfop,
                        ValorFrete = item.ValorFrete,
                        ValorSeguro = item.ValorSeguro,
                        ValorOutrasDespesas = item.ValorOutrasDespesas,
                        PrIcms = item.PrIcms,
                        ValorIcms = item.ValorIcms,
                        PrIpi = item.PrIpi,
                        ValorIpi = item.ValorIpi,
                        PrPis = item.PrPis,
                        ValorPis = item.ValorPis,
                        PrCofinss = item.PrCofinss,
                        ValorCofins = item.ValorCofins,
                        PrIva = item.PrIva,
                        BaseCalculoSt = item.BaseCalculoSt,
                        ValorSt = item.ValorSt,
                        ValorNetPrice = item.ValorNetPrice,
                        ValorGrossPrice = item.ValorGrossPrice,
                    }).ToList(),
                };
            }

            return null;
        }
    }
}