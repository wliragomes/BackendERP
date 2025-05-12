using SharedKernel.SharedObjects.Paginations;
using Application.DTOs.Vendas.Filtro;
using SharedKernel.SharedObjects;
using Application.DTOs.Vendas.TiposFretes.Filtro;
using Application.DTOs.TiposFretes.Filtro;
using Application.DTOs.Vendas.Relatorios;
using Application.DTOs.Pessoas.Filtro;

namespace Application.Interfaces.Queries
{
    public interface IVendaQuery
    {
        Task<PaginacaoResponse<VendaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<VendaOfRomaneioDto?>> RetornarVendaOfRomaneio(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno);
        Task<VendaByCodeDto?> RetornarPorId(Guid id);
        Task<VendaOrdemFabricacaoFilterDto?> RetornarOrdemFabricacao(string codigoAnoVenda);
        Task<PaginacaoResponse<TipoFreteFilterDto>> RetornarTipoFretePaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoFreteByCodeDto?> RetornarTipoFretePorId(Guid id);
        Task<List<OrcamentoPedidoImpressaoDto>> RetornarImpressao(Guid idVenda);
        Task<List<OrcamentoPedidoImpressaoDto>> RetornarImpressaoNew(Guid idVenda, bool especial, bool orcamento, Guid idCliente, bool suprimirVendedor);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoFechamentoPaginacao(PaginacaoRequest paginacaoRequest);
    }
}
