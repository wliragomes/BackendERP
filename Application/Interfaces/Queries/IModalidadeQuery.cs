using Application.DTOs.Modalidades.Filtro;
using Application.DTOs.Modalidades;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IModalidadeQuery
    {
        Task<PaginacaoResponse<ModalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<ModalidadeByCodeDto?> RetornarPorId(Guid id);
    }
}
