using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Pessoas.Filtro;
using Application.DTOs.Pessoas.TipoConsumidores.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IPessoaQuery
    {
        Task<PaginacaoResponse<PessoaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PessoaByIdDto?> RetornarPorId(Guid id);
        Task<PadraoIdDescricaoFilterDto?> RetornarOrigemPorId(Guid id);
        Task<PadraoIdDescricaoFilterDto?> RetornarRegiaoPorId(Guid id);
        Task<PadraoIdDescricaoFilterDto?> RetornarSegmentoClientePorId(Guid id);
        Task<PadraoIdDescricaoFilterDto?> RetornarSegmentoEstrategicoPorId(Guid id);
        Task<PadraoIdDescricaoFilterDto?> RetornarDepartamentoPorId(Guid id);
        Task<PadraoIdDescricaoFilterDto?> RetornarCargoPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarOrigemPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarRegiaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSegmentoClientePaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSegmentoEstrategicoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarDepartamentoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarCargoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<TipoConsumidorFilterDto>> RetornarTipoConsumidorPaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoConsumidorByCodeDto?> RetornarTipoConsumidorPorId(Guid id);        
    }
}

