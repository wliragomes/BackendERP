using Application.DTOs.Representantes.Adicionar;
using Application.DTOs.Representantes.Atualizar;
using Application.DTOs.Representantes.Excluir;
using Application.DTOs.Representantes.Filtro;
using Application.DTOs.Representantes;
using Domain.Commands.Representantes.Adicionar;
using Domain.Commands.Representantes.Atualizar;
using Domain.Commands.Representantes.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Representantes
{
    public interface IRepresentanteService
    {
        Task<FormularioResponse<AdicionarRepresentanteCommand>> Adicionar(AdicionarRepresentanteRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarRepresentanteCommand>> Atualizar(AtualizarRepresentanteRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirRepresentanteCommand>>> Excluir(ExcluirRepresentanteDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<RepresentanteFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<RepresentanteByCodeDto?> RetornarPorId(Guid id);
    }
}
