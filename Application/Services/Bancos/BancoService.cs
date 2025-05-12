using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Bancos;
using Application.Interfaces.Queries;
using Application.DTOs.Bancos;
using Application.DTOs.Bancos.Filtro;
using Application.DTOs.Bancos.Excluir;
using Application.DTOs.Bancos.Atualizar;
using Application.DTOs.Bancos.Adicionar;
using Domain.Commands.Bancos.Adicionar;
using Domain.Commands.Bancos.Atualizar;
using Domain.Commands.Bancos.Excluir;

namespace Application.Services.Bancos
{
    public class BancoService : IBancoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IBancoQuery _BancoQuery;

        public BancoService(IMapper mapper, IMediatrHandler mediatorHandler, IBancoQuery BancoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _BancoQuery = BancoQuery;
        }

        public async Task<FormularioResponse<AdicionarBancoCommand>> Adicionar(AdicionarBancoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarBancoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarBancoCommand>> Atualizar(AtualizarBancoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarBancoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirBancoCommand>>> Excluir(ExcluirBancoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirBancoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirBancoCommand, ExcluirBancoCommand>(commands);
        }

        public async Task<PaginacaoResponse<BancoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _BancoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<BancoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _BancoQuery.RetornarPorId(id);
        }
    }
}