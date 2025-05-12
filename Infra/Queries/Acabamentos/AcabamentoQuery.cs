using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Acabamentos.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Acabamentos;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Acabamentos
{
    public class AcabamentoQuery : IAcabamentoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public AcabamentoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<AcabamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Acabamento.AsNoTracking();

            var data = query.Select(x => new AcabamentoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Tolerancia = x.Tolerancia

            });

            var response = await data.RetonarFiltroCustomizado<AcabamentoFilterDto, AcabamentoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<AcabamentoByCodeDto?> RetornarPorId(Guid id)
        {
            var Acabamento = await _dbContext.Acabamento
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Acabamento != null)
            {
                return new AcabamentoByCodeDto
                {
                    Id = Acabamento.Id,
                    Descricao = Acabamento.Descricao,
                    Tolerancia = Acabamento.Tolerancia
                };
            }

            return null;
        }
    }
}
