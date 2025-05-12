using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Classificacoes.Filtro;
using Application.DTOs.Classificacoes;
using Application.DTOs.Operacoes.Filtro;
using Application.DTOs.Operacoes;
using Application.DTOs.ContasAPagar.Filtro;
using Application.DTOs.ContasAPagar;
using Application.DTOs.Cartoes.Filtro;
using Application.DTOs.ContasAPagarPago.Filtro;
using Application.DTOs.ContasAPagarPago;
using Application.DTOs.ContasAReceber.Filtro;
using Application.DTOs.ContasAReceber;
using Application.DTOs.Financeiros;
using Application.DTOs.PlanosDeContas.Filtro;
using Application.DTOs.PlanosDeContas;
using Application.DTOs.Financeiros.ContasAReceber.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IFinanceiroQuery
    {
        Task<PaginacaoResponse<CentroCustoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<CentroCustoFilterDto>> RetornarCentroCustoContaAReceberPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<ClassificacaoFilterDto>> RetornarClassificacaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ClassificacaoByCodeDto?> RetornarClassificacaoPorId(Guid id);
        Task<List<DespesaByCodeDto?>> RetornarDespesaCentroCusto(Guid idCentroCusto);
        Task<List<DespesaByCodeDto?>> RetornarDespesaCentroCustoContaAReceber(Guid idCentroCustoContaAReceber);
        Task<PaginacaoResponse<OperacaoFilterDto>> RetornarOperacaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<OperacaoByCodeDto?> RetornarOperacaoPorId(Guid id);
        Task<PaginacaoResponse<ContaAPagarFilterDto>> RetornarContaAPagarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ContaAPagarByCodeDto?> RetornarContaAPagarPorId(Guid id);
        Task<PaginacaoResponse<CartaoFilterDto>> RetornarCartaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CartaoByCodeDto?> RetornarCartaoPorId(Guid id);
        Task<PaginacaoResponse<ContaAPagarPagoFilterDto>> RetornarContaAPagarPagoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ContaAPagarPagoByCodeDto?> RetornarContaAPagarPagoPorId(Guid id);
        Task<PaginacaoResponse<ContaAReceberFilterDto>> RetornarContaAReceberPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ContaAReceberByCodeDto?> RetornarContaAReceberPorId(Guid id);
        Task<List<ContaAReceberGetDto?>> RetornarContaAReceber(string? status, DateTime? dataInicial, DateTime? dataFinal);
        Task<PaginacaoResponse<PlanoDeContasFilterDto>> RetornarPlanoDeContasPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PlanoDeContasByCodeDto?> RetornarPlanoDeContasPorId(Guid id);
    }
}
