using Application.DTOs.Parametros.Filtro;
using Application.DTOs.Parametros;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IParametroQuery
    {        
        Task<PaginacaoResponse<ParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<ParametroMedidaDto>> RetornarParametroMedida(PaginacaoRequest paginacaoRequest);
        Task<ParametroByCodeDto?> RetornarPorId(Guid id);
    }
}
