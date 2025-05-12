using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.NormasAbnts.Filtro;
using Application.DTOs.NormasAbnts;
using Application.Interfaces.Queries;

namespace Infra.Queries.NormasAbnts
{
    public class NormaAbntQuery : INormaAbntQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public NormaAbntQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public async Task<PaginacaoResponse<NormaAbntFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.NormaAbnt.AsNoTracking();

            var data = query.Select(x => new NormaAbntFilterDto
            {
                Id = x.Id,                
                NNbr = x.Numero,
                Descricao = x.Descricao,
                Pedido = x.Pedido,
                Validade = x.Validade,
                Vencida = x.Vencida,
            });

            var response = await data.RetonarFiltroCustomizado<NormaAbntFilterDto, NormaAbntFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<NormaAbntByCodeDto?> RetornarPorId(Guid id)
        {
            var normaAbnt = await _dbContext.NormaAbnt
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (normaAbnt != null)
            {
                return new NormaAbntByCodeDto
                {
                    Id = normaAbnt.Id,                    
                    NNbr = normaAbnt.Numero,
                    Descricao = normaAbnt.Descricao,
                    Pedido = normaAbnt.Pedido,
                    Validade = normaAbnt.Validade,
                    Vencida = normaAbnt.Vencida,
                };
            }

            return null;
        }
    }
}
