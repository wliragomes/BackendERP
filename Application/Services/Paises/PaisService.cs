using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Paises;
using Application.Interfaces.Queries;
using Application.DTOs.Paises;
using Application.DTOs.Paises.Filtro;
using Application.DTOs.Paises.Excluir;
using Application.DTOs.Paises.Atualizar;
using Application.DTOs.Paises.Adicionar;
using Domain.Commands.Paises.Adicionar;
using Domain.Commands.Paises.Atualizar;
using Domain.Commands.Paises.Excluir;

namespace Application.Services.Paises
{
    public class PaisService : IPaisService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IPaisQuery _PaisQuery;

        public PaisService(IMapper mapper, IMediatrHandler mediatorHandler, IPaisQuery PaisQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _PaisQuery = PaisQuery;
        }

        public async Task<FormularioResponse<AdicionarPaisCommand>> Adicionar(AdicionarPaisRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarPaisCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarPaisCommand>> Atualizar(AtualizarPaisRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarPaisCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirPaisCommand>>> Excluir(ExcluirPaisDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirPaisCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirPaisCommand, ExcluirPaisCommand>(commands);
        }

        public async Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _PaisQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacaoDapper(DapperPaginacaoRequest paginacaoRequest)
        {
            return await _PaisQuery.RetornarPaginacaoDapper(paginacaoRequest);
        }

        public async Task<PaisByCodeDto?> RetornarPorId(Guid id)
        {
            return await _PaisQuery.RetornarPorId(id);
        }
    }
}