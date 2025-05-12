using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.RegimeTributarios;
using Application.Interfaces.Queries;
using Application.DTOs.RegimeTributarios;
using Application.DTOs.RegimeTributarios.Filtro;
using Application.DTOs.RegimeTributarios.Excluir;
using Application.DTOs.RegimeTributarios.Atualizar;
using Application.DTOs.RegimeTributarios.Adicionar;
using Domain.Commands.RegimeTributarios.Adicionar;
using Domain.Commands.RegimeTributarios.Atualizar;
using Domain.Commands.RegimeTributarios.Excluir;

namespace Application.Services.RegimeTributarios
{
    public class RegimeTributarioService : IRegimeTributarioService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IRegimeTributarioQuery _RegimeTributarioQuery;

        public RegimeTributarioService(IMapper mapper, IMediatrHandler mediatorHandler, IRegimeTributarioQuery RegimeTributarioQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _RegimeTributarioQuery = RegimeTributarioQuery;
        }

        public async Task<FormularioResponse<AdicionarRegimeTributarioCommand>> Adicionar(AdicionarRegimeTributarioRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarRegimeTributarioCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarRegimeTributarioCommand>> Atualizar(AtualizarRegimeTributarioRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarRegimeTributarioCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirRegimeTributarioCommand>>> Excluir(ExcluirRegimeTributarioDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirRegimeTributarioCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirRegimeTributarioCommand, ExcluirRegimeTributarioCommand>(commands);
        }

        public async Task<PaginacaoResponse<RegimeTributarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _RegimeTributarioQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<RegimeTributarioByCodeDto?> RetornarPorId(Guid id)
        {
            return await _RegimeTributarioQuery.RetornarPorId(id);
        }
    }
}