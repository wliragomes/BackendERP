using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Configuration.Extensions;
using Application.DTOs.Pessoas.Filtro;

namespace Infra.Queries.MovimentosEstoque
{
    public class MovimentoEstoqueQuery : IMovimentoEstoqueQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public MovimentoEstoqueQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.MovimentoEstoque.AsNoTracking();

            var data = query.Select(x => new PadraoIdDescricaoFilterDto
            {
                Id = x.Id,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<PadraoIdDescricaoFilterDto, PadraoIdDescricaoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<PadraoIdDescricaoFilterDto?> RetornarPorId(Guid id)
        {
            var MovimentoEstoque = await _dbContext.MovimentoEstoque
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (MovimentoEstoque != null)
            {
                return new PadraoIdDescricaoFilterDto
                {
                    Id = MovimentoEstoque.Id,
                    Descricao = MovimentoEstoque.Descricao
                };
            }

            return null;
        }
    }
}
