using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Venda.Adicionar;
using Application.DTOs.Venda.Excluir;
using Domain.Commands.Vendas.Adicionar;
using Application.DTOs.Vendas.Filtro;
using Domain.Commands.Vendas.Excluir;
using Domain.Commands.Vendas.Atualizar;
using Application.DTOs.Venda.Atualizar;
using Application.DTOs.TiposFretes.Adicionar;
using Application.DTOs.TiposFretes.Atualizar;
using Application.DTOs.TiposFretes.Excluir;
using Application.DTOs.TiposFretes.Filtro;
using Application.DTOs.Vendas.TiposFretes.Filtro;
using Domain.Commands.TipoFretes.Excluir;
using Domain.Commands.TipoFretes.Atualizar;
using Domain.Commands.TipoFretes.Adicionar;
using Application.DTOs.Pessoas.Filtro;

namespace Application.Interfaces.Vendas
{
    public interface IVendaService
    {
        Task<FormularioResponse<AdicionarVendaCommand>> Adicionar(AdicionarVendaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarVendaCommand>> Atualizar(AtualizarVendaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirVendaCommand>>> Excluir(ExcluirVendaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<VendaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        //Task<PaginacaoResponse<VendaOrdemFabricacaoFilterDto>> RetornarOrdemFabricacaoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<VendaOfRomaneioDto?>> RetornarVendaOfRomaneio(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno);
        Task<VendaByCodeDto?> RetornarPorId(Guid id);
        Task<VendaOrdemFabricacaoFilterDto?> RetornarOrdemFabricacao(string codigoAnoVenda);
        Task<FormularioResponse<AdicionarTipoFreteCommand>> AdicionarTipoFrete(AdicionarTipoFreteRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarTipoFreteCommand>> AtualizarTipoFrete(AtualizarTipoFreteRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirTipoFreteCommand>>> ExcluirTipoFrete(ExcluirTipoFreteDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<TipoFreteFilterDto>> RetornarTipoFretePaginacao(PaginacaoRequest paginacaoRequest);
        Task<TipoFreteByCodeDto?> RetornarTipoFretePorId(Guid id);
        Task<byte[]> RetornarImpressao(Guid idVenda, bool especial, bool orcamento, Guid idCliente, bool suprimirVendedor);
        Task<PaginacaoResponse<PadraoIdDescricaoFilterDto>> RetornarTipoFechamentoPaginacao(PaginacaoRequest paginacaoRequest);
    }
}
