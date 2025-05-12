using Application.Interfaces.Queries;
using Infra.Context;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.MotivoCancelamentos.Filtro;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.MotivoCancelamentos;
using SharedKernel.Configuration.Extensions;

namespace Infra.Queries.MotivoCancelamentos
{
    public class MotivoCancelamentoQuery : IMotivoCancelamentoQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public MotivoCancelamentoQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginacaoResponse<MotivoCancelamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            var query = _dbContext.MotivoCancelamento.AsNoTracking();

            var data = query.Select(x => new MotivoCancelamentoFilterDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao
            });

            var response = await data.RetonarFiltroCustomizado<MotivoCancelamentoFilterDto, MotivoCancelamentoFilterDto>(paginacaoRequest);
            return response;
        }

        public async Task<MotivoCancelamentoByCodeDto?> RetornarPorId(Guid id)
        {
            var MotivoCancelamento = await _dbContext.MotivoCancelamento
            .AsNoTracking()
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (MotivoCancelamento != null)
            {
                return new MotivoCancelamentoByCodeDto
                {
                    Id = MotivoCancelamento.Id,
                    Nome = MotivoCancelamento.Nome,
                    Descricao = MotivoCancelamento.Descricao,
                    Pedido = MotivoCancelamento.Pedido,
                    Orcamento = MotivoCancelamento.Orcamento,
                    PedidoInativo = MotivoCancelamento.PedidoInativo,
                    OrcamentoInativo = MotivoCancelamento.OrcamentoInativo,
                };
            }

            return null;
        }
    }
}
