using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Bancos;
using Application.Interfaces.Queries;
using Application.DTOs.Funcionalidades.Adicionar;
using Application.DTOs.Funcionalidades.Atualizar;
using Application.DTOs.Funcionalidades.Excluir;
using Application.DTOs.Funcionalidades.Filtro;
using Application.DTOs.Funcionalidades;
using Domain.Commands.Funcionalidades.Adicionar;
using Domain.Commands.Funcionalidades.Atualizar;
using Domain.Commands.Funcionalidades.Excluir;
using Application.DTOs.NiveisAcessos;

namespace Application.Services.Bancos
{
    public class FuncionalidadeService : IFuncionalidadeService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IFuncionalidadeQuery _FuncionalidadeQuery;

        public FuncionalidadeService(IMapper mapper, IMediatrHandler mediatorHandler, IFuncionalidadeQuery funcionalidadeQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _FuncionalidadeQuery = funcionalidadeQuery;
        }

        public async Task<FormularioResponse<AdicionarFuncionalidadeCommand>> Adicionar(AdicionarFuncionalidadeRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarFuncionalidadeCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarFuncionalidadeCommand>> Atualizar(AtualizarFuncionalidadeRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarFuncionalidadeCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirFuncionalidadeCommand>>> Excluir(ExcluirFuncionalidadeDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirFuncionalidadeCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirFuncionalidadeCommand, ExcluirFuncionalidadeCommand>(commands);
        }

        public async Task<PaginacaoResponse<FuncionalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _FuncionalidadeQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<FuncionalidadeByCodeDto?> RetornarPorId(Guid id)
        {
            return await _FuncionalidadeQuery.RetornarPorId(id);
        }

        public async Task<List<NivelAcessoByCodeDto>> RetornarPorIdFuncionalidade(Guid id)
        {
            return await _FuncionalidadeQuery.RetornarPorIdFuncionalidade(id);
        }
    }
}