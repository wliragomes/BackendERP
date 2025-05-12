using AutoMapper;
using SharedKernel.MediatR;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Empresas;
using Application.DTOs.Empresas;
using Application.DTOs.Empresas.Filtro;
using Application.DTOs.Empresas.Excluir;
using Application.DTOs.Empresas.Atualizar;
using Application.DTOs.Empresas.Adicionar;
using Domain.Commands.Empresas.Adicionar;
using Domain.Commands.Empresas.Atualizar;
using Domain.Commands.Empresas.Excluir;
using Application.Interfaces.Queries;

namespace Application.Services.Empresas
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IEmpresaQuery _EmpresaQuery;

        public EmpresaService(IMapper mapper, IMediatrHandler mediatorHandler, IEmpresaQuery EmpresaQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _EmpresaQuery = EmpresaQuery;
        }

        public async Task<FormularioResponse<AdicionarEmpresaCommand>> Adicionar(AdicionarEmpresaRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarEmpresaCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarEmpresaCommand>> Atualizar(AtualizarEmpresaRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarEmpresaCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirEmpresaCommand>>> Excluir(ExcluirEmpresaDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirEmpresaCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirEmpresaCommand, ExcluirEmpresaCommand>(commands);
        }

        public async Task<PaginacaoResponse<EmpresaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _EmpresaQuery.RetornarPaginacao(paginacaoRequest);
        }

        public async Task<EmpresaByCodeDto?> RetornarPorId(Guid id)
        {
            return await _EmpresaQuery.RetornarPorId(id);
        }
    }
}