using Application.DTOs.Empresas.Adicionar;
using Application.DTOs.Empresas.Atualizar;
using Application.DTOs.Empresas.Excluir;
using Application.DTOs.Empresas.Filtro;
using Application.DTOs.Empresas;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Domain.Commands.Empresas.Excluir;
using Domain.Commands.Empresas.Atualizar;
using Domain.Commands.Empresas.Adicionar;

namespace Application.Interfaces.Empresas
{
    public interface IEmpresaService
    {
        Task<FormularioResponse<AdicionarEmpresaCommand>> Adicionar(AdicionarEmpresaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarEmpresaCommand>> Atualizar(AtualizarEmpresaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirEmpresaCommand>>> Excluir(ExcluirEmpresaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<EmpresaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<EmpresaByCodeDto?> RetornarPorId(Guid id);
    }
}
