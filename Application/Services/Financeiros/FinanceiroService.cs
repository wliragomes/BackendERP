using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Financeiros;
using Application.Interfaces.Queries;
using Application.DTOs.Classificacoes.Atualizar;
using Application.DTOs.Classificacoes.Excluir;
using Application.DTOs.Classificacoes.Filtro;
using Application.DTOs.Classificacoes;
using Domain.Commands.Classificacoes.Excluir;
using Domain.Commands.Classificacoes.Atualizar;
using Domain.Commands.Classificacoes.Adicionar;
using Application.DTOs.Classificacoes.Adicionar;
using Application.DTOs.Operacoes.Adicionar;
using Application.DTOs.Operacoes.Atualizar;
using Application.DTOs.Operacoes.Excluir;
using Application.DTOs.Operacoes.Filtro;
using Application.DTOs.Operacoes;
using Domain.Commands.Operacoes.Adicionar;
using Domain.Commands.Operacoes.Atualizar;
using Domain.Commands.Operacoes.Excluir;
using Application.DTOs.ContasAPagar.Adicionar;
using Application.DTOs.ContasAPagar.Atualizar;
using Application.DTOs.ContasAPagar.Excluir;
using Application.DTOs.ContasAPagar.Filtro;
using Application.DTOs.ContasAPagar;
using Domain.Commands.ContasAPagar.Adicionar;
using Domain.Commands.ContasAPagar.Atualizar;
using Domain.Commands.ContasAPagar.Excluir;
using Application.DTOs.Cartoes.Adicionar;
using Application.DTOs.Cartoes.Atualizar;
using Application.DTOs.Cartoes.Excluir;
using Application.DTOs.Cartoes.Filtro;
using Domain.Commands.Cartoes.Adicionar;
using Domain.Commands.Cartoes.Atualizar;
using Domain.Commands.Cartoes.Excluir;
using Application.DTOs.ContasAPagarPago.Adicionar;
using Application.DTOs.ContasAPagarPago.Atualizar;
using Application.DTOs.ContasAPagarPago.Excluir;
using Application.DTOs.ContasAPagarPago.Filtro;
using Application.DTOs.ContasAPagarPago;
using Domain.Commands.ContasAPagarPago.Adicionar;
using Domain.Commands.ContasAPagarPago.Atualizar;
using Domain.Commands.ContasAPagarPago.Excluir;
using Application.DTOs.ContasAReceber.Adicionar;
using Application.DTOs.ContasAReceber.Atualizar;
using Application.DTOs.ContasAReceber.Excluir;
using Application.DTOs.ContasAReceber.Filtro;
using Application.DTOs.ContasAReceber;
using Domain.Commands.ContasAReceber.Adicionar;
using Domain.Commands.ContasAReceber.Atualizar;
using Domain.Commands.ContasAReceber.Excluir;
using Application.DTOs.Financeiros;
using Application.DTOs.PlanosDeContas.Adicionar;
using Application.DTOs.PlanosDeContas.Atualizar;
using Application.DTOs.PlanosDeContas.Excluir;
using Application.DTOs.PlanosDeContas.Filtro;
using Application.DTOs.PlanosDeContas;
using Domain.Commands.PlanosDeContas.Adicionar;
using Domain.Commands.PlanosDeContas.Atualizar;
using Domain.Commands.PlanosDeContas.Excluir;
using Application.DTOs.Financeiros.ContasAReceber.Filtro;
using Application.DTOs.Comissoes;
namespace Application.Services.Financeiros;

public class FinanceiroService : IFinanceiroService
{
    private readonly IMapper _mapper;
    private readonly IMediatrHandler _mediatorHandler;
    private readonly IFinanceiroQuery _FinanceiroQuery;

    public FinanceiroService(IMapper mapper, IMediatrHandler mediatorHandler, IFinanceiroQuery FinanceiroQuery)
    {
        _mapper = mapper;
        _mediatorHandler = mediatorHandler;
        _FinanceiroQuery = FinanceiroQuery;
    }

    public async Task<PaginacaoResponse<CentroCustoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarPaginacao(paginacaoRequest);
    }

    public async Task<PaginacaoResponse<CentroCustoFilterDto>> RetornarCentroCustoContaAReceberPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarCentroCustoContaAReceberPaginacao(paginacaoRequest);
    }

    public async Task<FormularioResponse<AdicionarClassificacaoCommand>> AdicionarClassificacao(AdicionarClassificacaoRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarClassificacaoCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarClassificacaoCommand>> AtualizarClassificacao(AtualizarClassificacaoRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarClassificacaoCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirClassificacaoCommand>>> ExcluirClassificacao(ExcluirClassificacaoDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirClassificacaoCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirClassificacaoCommand, ExcluirClassificacaoCommand>(commands);
    }

    public async Task<PaginacaoResponse<ClassificacaoFilterDto>> RetornarClassificacaoPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarClassificacaoPaginacao(paginacaoRequest);
    }

    public async Task<ClassificacaoByCodeDto?> RetornarClassificacaoPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarClassificacaoPorId(id);
    }

    public async Task<List<DespesaByCodeDto?>> RetornarDespesaCentroCusto(Guid idCentroCusto)
    {
        return await _FinanceiroQuery.RetornarDespesaCentroCusto(idCentroCusto);
    }

    public async Task<List<DespesaByCodeDto?>> RetornarDespesaCentroCustoContaAReceber(Guid idCentroCustoContaAReceber)
    {
        return await _FinanceiroQuery.RetornarDespesaCentroCustoContaAReceber(idCentroCustoContaAReceber);
    }

    public async Task<FormularioResponse<AdicionarOperacaoCommand>> AdicionarOperacao(AdicionarOperacaoRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarOperacaoCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarOperacaoCommand>> AtualizarOperacao(AtualizarOperacaoRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarOperacaoCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirOperacaoCommand>>> ExcluirOperacao(ExcluirOperacaoDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirOperacaoCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirOperacaoCommand, ExcluirOperacaoCommand>(commands);
    }

    public async Task<PaginacaoResponse<OperacaoFilterDto>> RetornarOperacaoPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarOperacaoPaginacao(paginacaoRequest);
    }

    public async Task<OperacaoByCodeDto?> RetornarOperacaoPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarOperacaoPorId(id);
    }

    public async Task<FormularioResponse<AdicionarContaAPagarCommand>> AdicionarContaAPagar(AdicionarContaAPagarRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarContaAPagarCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarContaAPagarCommand>> AtualizarContaAPagar(AtualizarContaAPagarRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarContaAPagarCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirContaAPagarCommand>>> ExcluirContaAPagar(ExcluirContaAPagarDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirContaAPagarCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirContaAPagarCommand, ExcluirContaAPagarCommand>(commands);
    }

    public async Task<PaginacaoResponse<ContaAPagarFilterDto>> RetornarContaAPagarPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarContaAPagarPaginacao(paginacaoRequest);
    }

    public async Task<ContaAPagarByCodeDto?> RetornarContaAPagarPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarContaAPagarPorId(id);
    }

    public async Task<FormularioResponse<AdicionarCartaoCommand>> AdicionarCartao(AdicionarCartaoRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarCartaoCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarCartaoCommand>> AtualizarCartao(AtualizarCartaoRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarCartaoCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirCartaoCommand>>> ExcluirCartao(ExcluirCartaoDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirCartaoCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirCartaoCommand, ExcluirCartaoCommand>(commands);
    }

    public async Task<PaginacaoResponse<CartaoFilterDto>> RetornarCartaoPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarCartaoPaginacao(paginacaoRequest);
    }

    public async Task<CartaoByCodeDto?> RetornarCartaoPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarCartaoPorId(id);
    }

    public async Task<FormularioResponse<AdicionarContaAPagarPagoCommand>> AdicionarContaAPagarPago(AdicionarContaAPagarPagoRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarContaAPagarPagoCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarContaAPagarPagoCommand>> AtualizarContaAPagarPago(AtualizarContaAPagarPagoRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarContaAPagarPagoCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirContaAPagarPagoCommand>>> ExcluirContaAPagarPago(ExcluirContaAPagarPagoDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirContaAPagarPagoCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirContaAPagarPagoCommand, ExcluirContaAPagarPagoCommand>(commands);
    }

    public async Task<PaginacaoResponse<ContaAPagarPagoFilterDto>> RetornarContaAPagarPagoPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarContaAPagarPagoPaginacao(paginacaoRequest);
    }

    public async Task<ContaAPagarPagoByCodeDto?> RetornarContaAPagarPagoPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarContaAPagarPagoPorId(id);
    }

    public async Task<FormularioResponse<AdicionarContaAReceberCommand>> AdicionarContaAReceber(AdicionarContaAReceberRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarContaAReceberCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarContaAReceberCommand>> AtualizarContaAReceber(AtualizarContaAReceberRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarContaAReceberCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirContaAReceberCommand>>> ExcluirContaAReceber(ExcluirContaAReceberDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirContaAReceberCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirContaAReceberCommand, ExcluirContaAReceberCommand>(commands);
    }

    public async Task<PaginacaoResponse<ContaAReceberFilterDto>> RetornarContaAReceberPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarContaAReceberPaginacao(paginacaoRequest);
    }

    public async Task<ContaAReceberByCodeDto?> RetornarContaAReceberPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarContaAReceberPorId(id);
    }

    public async Task<List<ContaAReceberGetDto?>> RetornarContaAReceber(string? status, DateTime? dataInicial, DateTime? dataFinal)
    {
        return await _FinanceiroQuery.RetornarContaAReceber(status, dataInicial, dataFinal);
    }

    public async Task<FormularioResponse<AdicionarPlanoDeContasCommand>> AdicionarPlanoDeContas(AdicionarPlanoDeContasRequestDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<AdicionarPlanoDeContasCommand>(dtos);
        return await _mediatorHandler.SendCommand(commands);
    }

    public async Task<FormularioResponse<AtualizarPlanoDeContasCommand>> AtualizarPlanoDeContas(AtualizarPlanoDeContasRequestDto dto, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AtualizarPlanoDeContasCommand>(dto);
        return await _mediatorHandler.SendCommand(command);
    }

    public async Task<List<FormularioResponse<ExcluirPlanoDeContasCommand>>> ExcluirPlanoDeContas(ExcluirPlanoDeContasDto dtos, CancellationToken cancellationToken)
    {
        var commands = _mapper.Map<ExcluirPlanoDeContasCommand>(dtos);
        return await _mediatorHandler.SendCommandInBulk<ExcluirPlanoDeContasCommand, ExcluirPlanoDeContasCommand>(commands);
    }

    public async Task<PaginacaoResponse<PlanoDeContasFilterDto>> RetornarPlanoDeContasPaginacao(PaginacaoRequest paginacaoRequest)
    {
        return await _FinanceiroQuery.RetornarPlanoDeContasPaginacao(paginacaoRequest);
    }

    public async Task<PlanoDeContasByCodeDto?> RetornarPlanoDeContasPorId(Guid id)
    {
        return await _FinanceiroQuery.RetornarPlanoDeContasPorId(id);
    }
}
