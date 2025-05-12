using Application.DTOs.Comissoes.Filtro;
using Application.DTOs.Comissoes;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Queries
{
    public interface IComissaoQuery
    {
        Task<PaginacaoResponse<ComissaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<ComissaoGetDto?>> RetornarComissaoGet(Guid idPessoa, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, Guid? idStatus);
        Task<ComissaoByCodeDto?> RetornarPorId(Guid id);
    }
}
