using Application.DTOs.ObraFases.Adicionar;
using Application.DTOs.ObraFases.Atualizar;
using Application.DTOs.ObraFases.Excluir;
using Application.DTOs.ObraFases.Filtro;
using Application.DTOs.ObraFases;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.ObraFases.Excluir;
using Domain.Commands.ObraFases.Adicionar;
using Domain.Commands.ObraFases.Atualizar;
using Application.DTOs.ObraOrigens.Adicionar;
using Domain.Commands.ObraOrigems.Adicionar;
using Domain.Commands.ObraOrigems.Atualizar;
using Application.DTOs.ObraOrigens.Atualizar;
using Application.DTOs.ObraOrigens.Excluir;
using Domain.Commands.ObraOrigems.Excluir;
using Application.DTOs.ObraOrigens.Filtro;
using Application.DTOs.ObraOrigens;
using Application.DTOs.ObrasPadrao.Adicionar;
using Application.DTOs.ObrasPadrao.Atualizar;
using Application.DTOs.ObrasPadrao.Excluir;
using Application.DTOs.ObrasPadrao.Filtro;
using Application.DTOs.ObrasPadrao;
using Domain.Commands.ObrasPadrao.Adicionar;
using Domain.Commands.ObrasPadrao.Atualizar;
using Domain.Commands.ObrasPadrao.Excluir;
using Application.DTOs.ObrasProjetos.Adicionar;
using Application.DTOs.ObrasProjetos.Atualizar;
using Application.DTOs.ObrasProjetos.Excluir;
using Application.DTOs.ObrasProjetos.Filtro;
using Application.DTOs.ObrasProjetos;
using Domain.Commands.ObrasProjetos.Excluir;
using Domain.Commands.ObrasProjetos.Atualizar;
using Domain.Commands.ObrasProjetos.Adicionar;

namespace Application.Interfaces.Obras
{
    public interface IObraService
    {
        Task<FormularioResponse<AdicionarObraFaseCommand>> AdicionarObraFase(AdicionarObraFaseRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarObraFaseCommand>> AtualizarObraFase(AtualizarObraFaseRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirObraFaseCommand>>> ExcluirObraFase(ExcluirObraFaseDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ObraFaseFilterDto>> RetornarObraFasePaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraFaseByCodeDto?> RetornarObraFasePorId(Guid id);
        Task<FormularioResponse<AdicionarObraOrigemCommand>> AdicionarObraOrigem(AdicionarObraOrigemRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarObraOrigemCommand>> AtualizarObraOrigem(AtualizarObraOrigemRequestDto Dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirObraOrigemCommand>>> ExcluirObraOrigem(ExcluirObraOrigemDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ObraOrigemFilterDto>> RetornarObraOrigemPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraOrigemByCodeDto?> RetornarObraOrigemPorId(Guid id);
        Task<FormularioResponse<AdicionarObraPadraoCommand>> AdicionarObraPadrao(AdicionarObraPadraoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarObraPadraoCommand>> AtualizarObraPadrao(AtualizarObraPadraoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirObraPadraoCommand>>> ExcluirObraPadrao(ExcluirObraPadraoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ObraPadraoFilterDto>> RetornarObraPadraoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraPadraoByCodeDto?> RetornarObraPadraoPorId(Guid id);
        Task<FormularioResponse<AdicionarObraProjetoCommand>> AdicionarObraProjeto(AdicionarObraProjetoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarObraProjetoCommand>> AtualizarObraProjeto(AtualizarObraProjetoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirObraProjetoCommand>>> ExcluirObraProjeto(ExcluirObraProjetoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ObraProjetoFilterDto>> RetornarObraProjetoPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ObraProjetoByCodeDto?> RetornarObraProjetoPorId(Guid id);
    }
}
