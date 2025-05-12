using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Cfops.Adicionar;
using Application.DTOs.Cfops.Atualizar;
using Application.DTOs.Cfops.Excluir;
using Application.DTOs.Cfops.Filtro;
using Domain.Commands.Cfops.Adicionar;
using Domain.Commands.Cfops.Atualizar;
using Domain.Commands.Cfops.Excluir;
using Application.Interfaces.Cfops;
using Application.Interfaces.Queries;

namespace Application.Services.Cfops
{
    public class CfopService : ICfopService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly ICfopQuery _CfopQuery;

        public CfopService(IMapper mapper, IMediatrHandler mediatorHandler, ICfopQuery CfopQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _CfopQuery = CfopQuery;
        }

        public async Task<FormularioResponse<AdicionarCfopCommand>> Adicionar(AdicionarCfopRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCfopCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCfopCommand>> Atualizar(AtualizarCfopRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCfopCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCfopCommand>>> Excluir(ExcluirCfopDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCfopCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCfopCommand, ExcluirCfopCommand>(commands);
        }

        public async Task<PaginacaoResponse<CfopFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _CfopQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<CfopByCodeDto?> RetornarPorId(Guid id)
        {
            return await _CfopQuery.RetornarPorId(id);
        }

        public async Task<List<CfopFilterDto?>> RetornarCfopIpi(bool ipi)
        {
            return await _CfopQuery.RetornarCfopIpi(ipi);
        }
    }
}