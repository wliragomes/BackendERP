using Application.DTOs.ObraFases.Filtro;
using Application.DTOs.ObraFases;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.ObraOrigens.Filtro;
using Application.DTOs.ObraOrigens;
using Application.DTOs.ObrasPadrao.Filtro;
using Application.DTOs.ObrasPadrao;
using Application.DTOs.ObrasProjetos.Filtro;
using Application.DTOs.ObrasProjetos;

namespace Application.Interfaces.Queries
{
    public interface IObraQuery
    {
        Task<PaginacaoResponse<ObraFaseFilterDto>> RetornarObraFasePaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraFaseByCodeDto?> RetornarObraFasePorId(Guid id);
        Task<PaginacaoResponse<ObraOrigemFilterDto>> RetornarObraOrigemPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraOrigemByCodeDto?> RetornarObraOrigemPorId(Guid id);
        Task<PaginacaoResponse<ObraPadraoFilterDto>> RetornarObraPadraoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraPadraoByCodeDto?> RetornarObraPadraoPorId(Guid id);
        Task<PaginacaoResponse<ObraProjetoFilterDto>> RetornarObraProjetoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraProjetoByCodeDto?> RetornarObraProjetoPorId(Guid id);
    }
}
