using Application.DTOs.Impostos.CstIcmss.Adicionar;
using Application.DTOs.Impostos.CstIcmss.Atualizar;
using Application.DTOs.Impostos.CstIcmss.Excluir;
using Application.DTOs.Impostos.CstIcmss.Filtro;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.Impostos.CstIcmss.Adicionar;
using Domain.Commands.Impostos.CstIcmss.Atualizar;
using Domain.Commands.Impostos.CstIcmss.Excluir;
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
using Application.DTOs.Impostos.Piss.Atualizar;
using Application.DTOs.Impostos.Piss.Excluir;
using Application.DTOs.Impostos.Piss.Filtro;
using Domain.Commands.Impostos.Piss.Excluir;
using Domain.Commands.Impostos.Piss.Atualizar;
using Domain.Commands.Impostos.Piss.Adicionar;
using Application.DTOs.Impostos.Cofinss.Adicionar;
using Application.DTOs.Impostos.Cofinss.Atualizar;
using Application.DTOs.Impostos.Coffinss.Filtro;
using Application.DTOs.Impostos.Cofinss.Filtro;
using Domain.Commands.Impostos.Cofinss.Adicionar;
using Domain.Commands.Impostos.Cofinss.Atualizar;
using Domain.Commands.Impostos.Cofinss.Excluir;
using Application.DTOs.Impostos.Coffinss.Excluir;

namespace Application.Interfaces.Impostos
{
    public interface IImpostoService
    {
        Task<FormularioResponse<AdicionarCstIcmsCommand>> AdicionarCstIcms(AdicionarCstIcmsRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCST_ICMSCommand>> AtualizarCstIcms(AtualizarCstIcmsRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCstIcmsCommand>>> ExcluirCstIcms(ExcluirCST_ICMSDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CstIcmsFilterDto>> RetornarCstIcmsPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CstIcmsByCodeDto?> RetornarCstIcmsPorId(Guid id);
        Task<FormularioResponse<AdicionarCstIpiCommand>> AdicionarCstIpi(AdicionarCstIpiRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCstIpiCommand>> AtualizarCstIpi(AtualizarCstIpiRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCstIpiCommand>>> ExcluirCstIpi(ExcluirCstIpiDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CstIpiFilterDto>> RetornarCstIpiPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CstIpiByCodeDto?> RetornarCstIpiPorId(Guid id);
        Task<FormularioResponse<AdicionarIcstIcmsOrigemMaterialCommand>> AdicionarCstIcmsOrigemMaterial(AdicionarCstIcmsOrigemMaterialRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarIcstIcmsOrigemMaterialCommand>> AtualizarCstIcmsOrigemMaterial(AtualizarCstIcmsOrigemMaterialRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>>> ExcluirCstIcmsOrigemMaterial(ExcluirCstIcmsOrigemMaterialDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CstIcmsOrigemMaterialFilterDto>> RetornarCstIcmsOrigemMaterialPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CST_ICMS_Origem_MaterialByCodeDto?> RetornarCstIcmsOrigemMaterialPorId(Guid id);
        Task<FormularioResponse<AdicionarPisCommand>> AdicionarPis(AdicionarPisRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarPisCommand>> AtualizarPis(AtualizarPisRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirPisCommand>>> ExcluirPis(ExcluirPisDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<PisFilterDto>> RetornarPisPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PisByCodeDto?> RetornarPisPorId(Guid id);
        Task<FormularioResponse<AdicionarCofinsCommand>> AdicionarCofins(AdicionarCofinsRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCofinsCommand>> AtualizarCofins(AtualizarCofinsRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCofinsCommand>>> ExcluirCofins(ExcluirCofinsDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CofinsFilterDto>> RetornarCofinsPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CofinsByCodeDto?> RetornarCofinsPorId(Guid id);        
    }
}
