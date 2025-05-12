using Application.DTOs.OrdensFabricacoes.Filtro;
using Application.DTOs.OrdensFabricacoes;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Vendas.Filtro;
using Application.DTOs.OrdensFabricacoes.Relatorios;
using Application.DTOs.PlanejamentosProducoes;

namespace Application.Interfaces.Queries
{
    public interface IOrdemFabricacaoQuery
    {
        Task<PaginacaoResponse<OrdemFabricacaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<OrdemFabricacaoListaRomaneioDto>> RetornarOrdemFabricacaoRomaneioPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<OrdemFabricacaoGetDto>> RetornarOrdemFabricacaoGetPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<GetTemporarioDto?>> RetornarGetTemporarioPaginacao(Guid idVenda);
        Task<List<GetOrdemFabricacaoObterVendaDto?>> RetornarVendaPorOrdemFabricacao(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno);
        Task<EnderecoOrdemFabricacaoDto?> RetornarEnderecoOrdemFabricacao(Guid id, Guid idEnderecoEntrega);
        Task<OrdemFabricacaoByCodeDto?> RetornarPorId(Guid id);
        Task<OrdemFabricacaoItemDimensaoCalculoDto?> GetCalculoDimensoesItem(OrdemFabricacaoItemDimensaoDto dimensao);
        Task<OrdemFabricacaoCalculoLapidacaoDto?> GetCalculoLapidacaoItem(OrdemFabricacaoItemLapidacaoDto lapidacao);
        Task<List<ProformaClienteDto>> RetornarClienteProforma(Guid idOrdemFabricacao);
        Task<ResultadoOrdemFabricacaoResumoDto?> GetOrdemFabricacaoResumo(Guid idOrdemTmp);
    }
}
