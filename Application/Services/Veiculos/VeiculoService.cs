using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Caminhoes;
using Application.DTOs.Caminhoes.Filtro;
using Application.DTOs.Caminhoes.Excluir;
using Application.DTOs.Caminhoes.Atualizar;
using Application.DTOs.Caminhoes.Adicionar;
using Application.Interfaces.Queries;
using Application.DTOs.TiposCarrocerias.Adicionar;
using Application.DTOs.TiposCarrocerias.Atualizar;
using Application.DTOs.TiposCarrocerias.Excluir;
using Application.DTOs.TiposCarrocerias.Filtro;
using Application.DTOs.TiposCarrocerias;
using Application.DTOs.TiposRodados.Adicionar;
using Application.DTOs.TiposRodados.Atualizar;
using Application.DTOs.TiposRodados.Excluir;
using Application.DTOs.TiposRodados.Filtro;
using Application.DTOs.TiposRodados;
using Domain.Commands.TiposRodados.Adicionar;
using Domain.Commands.TiposRodados.Atualizar;
using Domain.Commands.TiposRodados.Excluir;
using Domain.Commands.Caminhoes.Excluir;
using Domain.Commands.Caminhoes.Atualizar;
using Domain.Commands.Caminhoes.Adicionar;
using Domain.Commands.TiposCarrocerias.Adicionar;
using Domain.Commands.TiposCarrocerias.Atualizar;
using Domain.Commands.TiposCarrocerias.Excluir;
using Application.Interfaces.Veiculos;

namespace Application.Services.Veiculos
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IVeiculoQuery _VeiculoQuery;

        public VeiculoService(IMapper mapper, IMediatrHandler mediatorHandler, IVeiculoQuery VeiculoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _VeiculoQuery = VeiculoQuery;
        }

        public async Task<FormularioResponse<AdicionarCaminhaoCommand>> Adicionar(AdicionarCaminhaoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCaminhaoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCaminhaoCommand>> Atualizar(AtualizarCaminhaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCaminhaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCaminhaoCommand>>> Excluir(ExcluirCaminhaoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCaminhaoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCaminhaoCommand, ExcluirCaminhaoCommand>(commands);
        }

        public async Task<PaginacaoResponse<CaminhaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _VeiculoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<CaminhaoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _VeiculoQuery.RetornarPorId(id);
        }

        public async Task<FormularioResponse<AdicionarTipoCarroceriaCommand>> AdicionarTipoCarroceria(AdicionarTipoCarroceriaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarTipoCarroceriaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarTipoCarroceriaCommand>> AtualizarTipoCarroceria(AtualizarTipoCarroceriaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarTipoCarroceriaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirTipoCarroceriaCommand>>> ExcluirTipoCarroceria(ExcluirTipoCarroceriaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirTipoCarroceriaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirTipoCarroceriaCommand, ExcluirTipoCarroceriaCommand>(commands);
        }

        public async Task<PaginacaoResponse<TipoCarroceriaFilterDto>> RetornarTipoCarroceriaPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _VeiculoQuery.RetornarTipoCarroceriaPaginacao(paginacaoRequest);
        }

        public async Task<TipoCarroceriaByCodeDto?> RetornarTipoCarroceriaPorId(Guid id)
        {
            return await _VeiculoQuery.RetornarTipoCarroceriaPorId(id);
        }

        public async Task<FormularioResponse<AdicionarTipoRodadoCommand>> AdicionarTipoRodado(AdicionarTipoRodadoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarTipoRodadoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarTipoRodadoCommand>> AtualizarTipoRodado(AtualizarTipoRodadoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarTipoRodadoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirTipoRodadoCommand>>> ExcluirTipoRodado(ExcluirTipoRodadoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirTipoRodadoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirTipoRodadoCommand, ExcluirTipoRodadoCommand>(commands);
        }

        public async Task<PaginacaoResponse<TipoRodadoFilterDto>> RetornarTipoRodadoPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _VeiculoQuery.RetornarTipoRodadoPaginacao(paginacaoRequest);
        }

        public async Task<TipoRodadoByCodeDto?> RetornarTipoRodadoPorId(Guid id)
        {
            return await _VeiculoQuery.RetornarTipoRodadoPorId(id);
        }
    }
}