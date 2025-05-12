using Application.DTOs.Caminhoes.Filtro;
using Application.DTOs.Caminhoes;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.TiposCarrocerias.Filtro;
using Application.DTOs.TiposCarrocerias;
using Application.DTOs.TiposRodados.Filtro;
using Application.DTOs.TiposRodados;

namespace Application.Interfaces.Queries
{
    public interface IVeiculoQuery
    {
        Task<PaginacaoResponse<CaminhaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CaminhaoByCodeDto?> RetornarPorId(Guid id);
        Task<PaginacaoResponse<TipoCarroceriaFilterDto>> RetornarTipoCarroceriaPaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoCarroceriaByCodeDto?> RetornarTipoCarroceriaPorId(Guid id);
        Task<PaginacaoResponse<TipoRodadoFilterDto>> RetornarTipoRodadoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoRodadoByCodeDto?> RetornarTipoRodadoPorId(Guid id);   
    }
}
