using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Comissoes;
using Application.Interfaces.Queries;
using Application.DTOs.Comissoes;
using Application.DTOs.Comissoes.Filtro;
using Application.DTOs.Comissoes.Excluir;
using Application.DTOs.Comissoes.Atualizar;
using Application.DTOs.Comissoes.Adicionar;
using Domain.Commands.Comissoes.Adicionar;
using Domain.Commands.Comissoes.Atualizar;
using Domain.Commands.Comissoes.Excluir;

namespace Application.Services.Comissoes
{
    public class ComissaoService : IComissaoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IComissaoQuery _ComissaoQuery;

        public ComissaoService(IMapper mapper, IMediatrHandler mediatorHandler, IComissaoQuery ComissaoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _ComissaoQuery = ComissaoQuery;
        }

        public async Task<FormularioResponse<AdicionarComissaoCommand>> Adicionar(AdicionarComissaoRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarComissaoCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarComissaoCommand>> Atualizar(AtualizarComissaoRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarComissaoCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirComissaoCommand>>> Excluir(ExcluirComissaoDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirComissaoCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirComissaoCommand, ExcluirComissaoCommand>(commands);
        }

        public async Task<PaginacaoResponse<ComissaoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _ComissaoQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<List<ComissaoGetDto>> RetornarComissaoGet(Guid idPessoa, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, Guid? idStatus)
        {
            return await _ComissaoQuery.RetornarComissaoGet(idPessoa, dataEmissaoInicial, dataEmissaoFinal, dataVencimentoInicial, dataVencimentoFinal, idStatus);
        }

        public async Task<ComissaoByCodeDto?> RetornarPorId(Guid id)
        {
            return await _ComissaoQuery.RetornarPorId(id);
        }
    }
}