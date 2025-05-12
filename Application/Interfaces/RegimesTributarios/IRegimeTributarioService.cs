using Application.DTOs.RegimeTributarios.Adicionar;
using Application.DTOs.RegimeTributarios.Atualizar;
using Application.DTOs.RegimeTributarios.Excluir;
using Application.DTOs.RegimeTributarios.Filtro;
using Application.DTOs.RegimeTributarios;
using Domain.Commands.RegimeTributarios.Adicionar;
using Domain.Commands.RegimeTributarios.Atualizar;
using Domain.Commands.RegimeTributarios.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.RegimeTributarios
{
    public interface IRegimeTributarioService
    {
        Task<FormularioResponse<AdicionarRegimeTributarioCommand>> Adicionar(AdicionarRegimeTributarioRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarRegimeTributarioCommand>> Atualizar(AtualizarRegimeTributarioRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirRegimeTributarioCommand>>> Excluir(ExcluirRegimeTributarioDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<RegimeTributarioFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<RegimeTributarioByCodeDto?> RetornarPorId(Guid id);
    }
}
