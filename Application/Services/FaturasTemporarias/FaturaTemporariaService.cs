using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects;
using Application.Interfaces.FaturaTemporarias;
using Application.Interfaces.Queries;
using Application.DTOs.FaturaTemporarias;
using Application.DTOs.FaturaTemporarias.Excluir;
using Application.DTOs.FaturaTemporarias.Adicionar;
using Domain.Commands.FaturaTemporarias.Adicionar;
using Domain.Commands.FaturaTemporarias.Excluir;

namespace Application.Services.FaturaTemporarias
{
    public class FaturaTemporariaService : IFaturaTemporariaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFaturaTemporariaQuery _FaturaTemporariaQuery;

        public FaturaTemporariaService(IMapper mapper, IMediatrHandler mediatorHandler, IFaturaTemporariaQuery FaturaTemporariaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _FaturaTemporariaQuery = FaturaTemporariaQuery;
        }

        public async Task<FormularioResponse<AdicionarFaturaTemporariaCommand>> Adicionar(AdicionarFaturaTemporariaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFaturaTemporariaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<List<FormularioResponse<ExcluirFaturaTemporariaCommand>>> Excluir(ExcluirFaturaTemporariaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFaturaTemporariaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFaturaTemporariaCommand, ExcluirFaturaTemporariaCommand>(commands);
        }

        public async Task<FaturaTemporariaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _FaturaTemporariaQuery.RetornarPorId(id);
        }
    }
}