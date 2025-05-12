using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Modalidades.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Modalidades;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.Modalidades
{
    public class ModalidadeQuery : IModalidadeQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public ModalidadeQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<ModalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.Modalidade.AsNoTracking();

            var data = query.Select(x => new ModalidadeFilterDto
            {
                Id = x.Id,
                DescricaoModalidade = x.DescricaoModalidade
            });

            var response = await data.RetonarFiltroCustomizado<ModalidadeFilterDto, ModalidadeFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<ModalidadeByCodeDto?> RetornarPorId(Guid id)
        {
            var Modalidade = await _dbContext.Modalidade
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (Modalidade != null)
            {
                return new ModalidadeByCodeDto
                {
                    Id = Modalidade.Id,
                    DescricaoModalidade = Modalidade.DescricaoModalidade,
                    ExigeNumero = Modalidade.ExigeNumero
                };
            }

            return null;
        }
    }
}
