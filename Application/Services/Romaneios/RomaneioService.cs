using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Romaneios;
using Application.Interfaces.Queries;
using Application.DTOs.Romaneios;
using Application.DTOs.Romaneios.Filtro;
using Application.DTOs.Romaneios.Excluir;
using Application.DTOs.Romaneios.Atualizar;
using Application.DTOs.Romaneios.Adicionar;
using Domain.Commands.Romaneios.Atualizar;
using Domain.Commands.Romaneios.Excluir;
using Domain.Commands.OrdensFabricacoes.Adicionar;

namespace Application.Services.Romaneios
{
    public class RomaneioService : IRomaneioService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IRomaneioQuery _RomaneioQuery;

        public RomaneioService(IMapper mapper, IMediatrHandler mediatorHandler, IRomaneioQuery RomaneioQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _RomaneioQuery = RomaneioQuery;
        }

        public async Task<FormularioResponse<AdicionarRomaneioCommand>> Adicionar(AdicionarRomaneioRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarRomaneioCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarRomaneioCommand>> Atualizar(AtualizarRomaneioRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarRomaneioCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirRomaneioCommand>>> Excluir(ExcluirRomaneioDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirRomaneioCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirRomaneioCommand, ExcluirRomaneioCommand>(commands);
        }

        public async Task<PaginacaoResponse<RomaneioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _RomaneioQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<List<RomaneioOfDto>> RetornarRomaneioOfs(int? sqRomaneioCodigo, int? sqRomaneioAno, int? sqOrdemFabricacaoCodigo, int? sqOrdemFabricacaoAno, Guid? idPessoa, DateTime? dataInicial, DateTime? dataFinal)
        {
            return await _RomaneioQuery.RetornarRomaneioOfs(sqRomaneioCodigo, sqRomaneioAno, sqOrdemFabricacaoCodigo, sqOrdemFabricacaoAno, idPessoa, dataInicial, dataFinal);
        }

        public async Task<List<RomaneioByCodeDto?>> RetornarPorId(Guid id)
        {
            return await _RomaneioQuery.RetornarPorId(id);
        }
    }
}