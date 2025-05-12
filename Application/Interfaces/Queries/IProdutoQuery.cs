using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Produtos.Filtro;
using Application.DTOs.Pessoas.Filtro;
using Application.DTOs.Produtos.Ncms.Filtro;
using Application.DTOs.Produtos.SetorProduto.Filtro;
using Application.DTOs.Produtos.UnidadesMedidas.Filtro;
using Application.DTOs.Produtos.ClasseReajustes.Filtro;
using Application.DTOs.Produtos.DesgastePolimentos.Filtro;
using Application.DTOs.Produtos;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;


namespace Application.Interfaces.Queries
{
    public interface IProdutoQuery
    {
        Task<PaginacaoResponse<ProdutoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        //Task<PaginacaoResponse<ProdutoOrdemFabricacaoFilterDto>> RetornarProdutoOrdemFabricacaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<ProdutoOrdemFabricacaoFilterDto?>> RetornarProdutoPorVendaPaginacao(Guid idVenda);
        Task<ProdutoByIdDto?> RetornarPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoProdutoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarTipoProdutoPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarGrupoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarGrupoPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarCodigoImportacaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarCodigoImportacaoPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSetorPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarSetorPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarRuaPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarRuaPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarSubgrupoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarSubgrupoPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarPrateleiraPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarPrateleiraPorId(Guid id);
        Task<PaginacaoResponse<NcmByCodeDto>> RetornarNcmPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<NcmByProdutoDto?>> RetornarNcmPorProduto(Guid id);
        Task<NcmByCodeDto?> RetornarNcmPorId(Guid id);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarFamiliaPaginacao(PaginacaoRequest paginacaoRequest); 
        Task<PadraoIdDescricaoFilterDto?> RetornarFamiliaPorId(Guid id);        
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoPrecoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarTipoPrecoPorId(Guid id);
        Task<PaginacaoResponse<SetorProdutoByCodeDto>> RetornarSetorProdutoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PadraoIdDescricaoFilterDto?> RetornarOrigemMaterialPorId(Guid id);
        Task<PaginacaoResponse<UnidadeMedidaByCodeDto>> RetornarUnidadeMedidaPaginacao(PaginacaoRequest paginacaoRequest);
        Task<UnidadeMedidaByCodeDto?> RetornarUnidadeMedidaPorId(Guid id);
        Task<SetorProdutoByCodeDto?> RetornarSetorProdutoPorId(Guid id);
        Task<List<SetorProdutoFilterDto?>> RetornarSetorProdutoPorCadastro(bool mostrarCadastro);
        Task<PaginacaoResponse<ClasseReajusteByCodeDto>> RetornarClasseReajustePaginacao(PaginacaoRequest paginacaoRequest);
        Task<ClasseReajusteByCodeDto?> RetornarClasseReajustePorId(Guid id);
        Task<PaginacaoResponse<DesgastePolimentoFilterDto>> RetornarDesgastePolimentoPaginacao(PaginacaoRequest paginacaoRequest);        
        Task<DesgastePolimentoByCodeDto?> RetornarDesgastePolimentoPorId(Guid id);


    }
}
