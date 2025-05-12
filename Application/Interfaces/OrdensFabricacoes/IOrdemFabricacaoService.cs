using Application.DTOs.OrdensFabricacoes.Adicionar;
using Application.DTOs.OrdensFabricacoes.Atualizar;
using Application.DTOs.OrdensFabricacoes.Excluir;
using Application.DTOs.OrdensFabricacoes.Filtro;
using Application.DTOs.OrdensFabricacoes;
using Domain.Commands.OrdensFabricacoes.Adicionar;
using Domain.Commands.OrdensFabricacoes.Atualizar;
using Domain.Commands.OrdensFabricacoes.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Vendas.Filtro;

namespace Application.Interfaces.OrdensFabricacoes
{
    public interface IOrdemFabricacaoService
    {
        Task<FormularioResponse<AdicionarOrdemFabricacaoCommand>> Adicionar(AdicionarOrdemFabricacaoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AdicionarOrdemFabricacaoTemporariaCommand>> AdicionarOrdemFabricacaoItemTemporaria(AdicionarOrdemFabricacaoTemporariaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarOrdemFabricacaoCommand>> Atualizar(AtualizarOrdemFabricacaoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirOrdemFabricacaoCommand>>> Excluir(ExcluirOrdemFabricacaoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<OrdemFabricacaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<OrdemFabricacaoListaRomaneioDto>> RetornarOrdemFabricacaoRomaneioPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<OrdemFabricacaoGetDto>> RetornarOrdemFabricacaoGetPaginacao(PaginacaoRequest paginacaoRequest);
        Task<List<GetTemporarioDto?>> RetornarGetTemporarioPaginacao(Guid idVenda);
        Task<List<GetOrdemFabricacaoObterVendaDto?>> RetornarVendaPorOrdemFabricacao(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno);
        Task<EnderecoOrdemFabricacaoDto?> RetornarEnderecoOrdemFabricacao(Guid id, Guid idEnderecoEntrega);
        Task<OrdemFabricacaoByCodeDto?> RetornarPorId(Guid id);
        Task<OrdemFabricacaoItemDimensaoCalculoDto?> GetCalculoDimensoesItem(OrdemFabricacaoItemDimensaoDto dimensao);
        Task<OrdemFabricacaoCalculoLapidacaoDto?> GetCalculoLapidacaoItem(OrdemFabricacaoItemLapidacaoDto lapidacao);
        Task<byte[]> RetornarRelatorioProforma(Guid idOrdemFabricacao);
        Task<ResultadoOrdemFabricacaoResumoDto?> GetOrdemFabricacaoResumo(Guid idOrdemTmp);
    }
}
