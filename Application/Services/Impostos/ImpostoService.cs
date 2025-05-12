using AutoMapper;
using SharedKernel.MediatR;
using Application.Interfaces.Impostos;
using Application.DTOs.Impostos.CstIcmss.Adicionar;
using Application.DTOs.Impostos.CstIcmss.Atualizar;
using Application.DTOs.Impostos.CstIcmss.Excluir;
using Application.DTOs.Impostos.CstIcmss.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.Impostos.CstIcmss.Adicionar;
using Domain.Commands.Impostos.CstIcmss.Atualizar;
using Domain.Commands.Impostos.CstIcmss.Excluir;
using Application.Interfaces.Queries;
using Application.DTOs.Impostos.CstIpis.Adicionar;
using Application.DTOs.Impostos.CstIpis.Atualizar;
using Application.DTOs.Impostos.CstIpis.Excluir;
using Application.DTOs.Impostos.CstIpis.Filtro;
using Application.DTOs.Impostos.CstIpis;
using Domain.Commands.Impostos.CstIpis.Adicionar;
using Domain.Commands.Impostos.CstIpis.Atualizar;
using Domain.Commands.Impostos.CstIpis.Excluir;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Adicionar;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Atualizar;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Excluir;
using Application.DTOs.Impostos.CstIcmsOrigemMateriais.Filtro;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Adicionar;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Atualizar;
using Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Excluir;
using Application.DTOs.Impostos.Piss.Adicionar;
using Domain.Commands.Paises.Adicionar;
using Domain.Commands.Paises.Atualizar;
using Application.DTOs.Impostos.Piss.Atualizar;
using Domain.Commands.Paises.Excluir;
using Application.DTOs.Impostos.Piss.Excluir;
using Application.DTOs.Impostos.Piss.Filtro;
using Domain.Commands.Impostos.Piss.Adicionar;
using Domain.Commands.Impostos.Piss.Atualizar;
using Domain.Commands.Impostos.Piss.Excluir;
using Application.DTOs.Impostos.Cofinss.Adicionar;
using Application.DTOs.Impostos.Cofinss.Atualizar;
using Application.DTOs.Impostos.Coffinss.Excluir;
using Application.DTOs.Impostos.Coffinss.Filtro;
using Application.DTOs.Impostos.Cofinss.Filtro;
using Domain.Commands.Impostos.Cofinss.Adicionar;
using Domain.Commands.Impostos.Cofinss.Atualizar;
using Domain.Commands.Impostos.Cofinss.Excluir;

namespace Application.Services.Produtos
{
    public class ImpostoService : IImpostoService
    {
        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatorHandler;
        private readonly IImpostoQuery _impostoQuery;

        public ImpostoService(IMapper mapper, IMediatrHandler mediatorHandler, IImpostoQuery impostoQuery)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
            _impostoQuery = impostoQuery;
        }

        public async Task<FormularioResponse<AdicionarCstIcmsCommand>> AdicionarCstIcms(AdicionarCstIcmsRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCstIcmsCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }        

        public async Task<FormularioResponse<AtualizarCST_ICMSCommand>> AtualizarCstIcms(AtualizarCstIcmsRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCST_ICMSCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }        

        public async Task<List<FormularioResponse<ExcluirCstIcmsCommand>>> ExcluirCstIcms(ExcluirCST_ICMSDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCstIcmsCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCstIcmsCommand, ExcluirCstIcmsCommand>(commands);
        }        

        public async Task<PaginacaoResponse<CstIcmsFilterDto>> RetornarCstIcmsPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _impostoQuery.RetornarCstIcmsPaginacao(paginacaoRequest);
        }

        public async Task<CstIcmsByCodeDto?> RetornarCstIcmsPorId(Guid id)
        {
            return await _impostoQuery.RetornarCstIcmsPorId(id);
        }

        public async Task<FormularioResponse<AdicionarCstIpiCommand>> AdicionarCstIpi(AdicionarCstIpiRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCstIpiCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCstIpiCommand>> AtualizarCstIpi(AtualizarCstIpiRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCstIpiCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCstIpiCommand>>> ExcluirCstIpi(ExcluirCstIpiDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCstIpiCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCstIpiCommand, ExcluirCstIpiCommand>(commands);
        }

        public async Task<PaginacaoResponse<CstIpiFilterDto>> RetornarCstIpiPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _impostoQuery.RetornarCstIpiPaginacao(paginacaoRequest);
        }

        public async Task<CstIpiByCodeDto?> RetornarCstIpiPorId(Guid id)
        {
            return await _impostoQuery.RetornarCstIpiPorId(id);
        }

        public async Task<FormularioResponse<AdicionarIcstIcmsOrigemMaterialCommand>> AdicionarCstIcmsOrigemMaterial(AdicionarCstIcmsOrigemMaterialRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarIcstIcmsOrigemMaterialCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarIcstIcmsOrigemMaterialCommand>> AtualizarCstIcmsOrigemMaterial(AtualizarCstIcmsOrigemMaterialRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarIcstIcmsOrigemMaterialCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>>> ExcluirCstIcmsOrigemMaterial(ExcluirCstIcmsOrigemMaterialDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirIcstIcmsOrigemMaterialCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirIcstIcmsOrigemMaterialCommand, ExcluirIcstIcmsOrigemMaterialCommand>(commands);
        }

        public async Task<PaginacaoResponse<CstIcmsOrigemMaterialFilterDto>> RetornarCstIcmsOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _impostoQuery.RetornarCstIcmsOrigemMaterialPaginacao(paginacaoRequest);
        }

        public async Task<CST_ICMS_Origem_MaterialByCodeDto?> RetornarCstIcmsOrigemMaterialPorId(Guid id)
        {
            return await _impostoQuery.RetornarCstIcmsOrigemMaterialPorId(id);
        }

        public async Task<FormularioResponse<AdicionarPisCommand>> AdicionarPis(AdicionarPisRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarPisCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarPisCommand>> AtualizarPis(AtualizarPisRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarPisCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirPisCommand>>> ExcluirPis(ExcluirPisDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirPisCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirPisCommand, ExcluirPisCommand>(commands);
        }

        public async Task<PaginacaoResponse<PisFilterDto>> RetornarPisPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _impostoQuery.RetornarPisPaginacao(paginacaoRequest);
        }

        public async Task<PisByCodeDto?> RetornarPisPorId(Guid id)
        {
            return await _impostoQuery.RetornarPisPorId(id);
        }

        public async Task<FormularioResponse<AdicionarCofinsCommand>> AdicionarCofins(AdicionarCofinsRequestDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<AdicionarCofinsCommand>(dtos);
            return await _mediatorHandler.SendCommand(commands);
        }

        public async Task<FormularioResponse<AtualizarCofinsCommand>> AtualizarCofins(AtualizarCofinsRequestDto dto, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarCofinsCommand>(dto);
            return await _mediatorHandler.SendCommand(command);
        }

        public async Task<List<FormularioResponse<ExcluirCofinsCommand>>> ExcluirCofins(ExcluirCofinsDto dtos, CancellationToken cancellationToken)
        {
            var commands = _mapper.Map<ExcluirCofinsCommand>(dtos);
            return await _mediatorHandler.SendCommandInBulk<ExcluirCofinsCommand, ExcluirCofinsCommand>(commands);
        }

        public async Task<PaginacaoResponse<CofinsFilterDto>> RetornarCofinsPaginacao(PaginacaoRequest paginacaoRequest)
        {
            return await _impostoQuery.RetornarCofinsPaginacao(paginacaoRequest);
        }

        public async Task<CofinsByCodeDto?> RetornarCofinsPorId(Guid id)
        {
            return await _impostoQuery.RetornarCofinsPorId(id);
        }
    }
}





