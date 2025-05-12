using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.NiveisAcessos.Filtro;
using Application.DTOs.NiveisAcessos;

namespace Application.Interfaces.Queries
{
    public interface INivelAcessoQuery
    {
        Task<PaginacaoResponse<NivelAcessoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);

        Task<NivelAcessoByCodeDto?> RetornarPorId(Guid id);
    }
}
