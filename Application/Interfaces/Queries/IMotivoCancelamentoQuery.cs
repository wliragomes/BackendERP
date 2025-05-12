using Application.DTOs.MotivoCancelamentos.Filtro;
using Application.DTOs.MotivoCancelamentos;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IMotivoCancelamentoQuery
    {
        Task<PaginacaoResponse<MotivoCancelamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<MotivoCancelamentoByCodeDto?> RetornarPorId(Guid id);
    }
}
