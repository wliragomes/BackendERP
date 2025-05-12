using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.ContasBancarias;
using Application.Interfaces.Queries;
using Application.DTOs.ContasBancarias;
using Application.DTOs.ContasBancarias.Filtro;
using Application.DTOs.ContasBancarias.Excluir;
using Application.DTOs.ContasBancarias.Atualizar;
using Application.DTOs.ContasBancarias.Adicionar;
using Domain.Commands.ContasBancarias.Adicionar;
using Domain.Commands.ContasBancarias.Atualizar;
using Domain.Commands.ContasBancarias.Excluir;

namespace Application.Services.ContasBancarias
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IContaBancariaQuery _ContaBancariaQuery;

        public ContaBancariaService(IMapper mapper, IMediatrHandler mediatorHandler, IContaBancariaQuery ContaBancariaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ContaBancariaQuery = ContaBancariaQuery;
        }

        public async Task<FormularioResponse<AdicionarContaBancariaCommand>> Adicionar(AdicionarContaBancariaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarContaBancariaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarContaBancariaCommand>> Atualizar(AtualizarContaBancariaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarContaBancariaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirContaBancariaCommand>>> Excluir(ExcluirContaBancariaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirContaBancariaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirContaBancariaCommand, ExcluirContaBancariaCommand>(commands);
        }

        public async Task<PaginacaoResponse<ContaBancariaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ContaBancariaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<ContaBancariaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _ContaBancariaQuery.RetornarPorId(id);
        }
    }
}