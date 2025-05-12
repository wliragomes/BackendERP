using Application.DTOs.Projetos.Filtro;
using Application.DTOs.Projetos;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IProjetoQuery
    {
        Task<PaginacaoResponse<ProjetoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<ProjetoByCodeDto?> RetornarPorId(Guid id);
    }
}
