using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.MotivoReposições.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IMotivoReposicaoQuery
    {
        Task<PaginacaoResponse<MotivoReposicaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<MotivoReposicaoByCodeDto?> RetornarPorId(Guid id);
    }
}
