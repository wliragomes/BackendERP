using Application.DTOs.Modalidades.Adicionar;
using Application.DTOs.Modalidades.Atualizar;
using Application.DTOs.Modalidades.Excluir;
using Application.DTOs.Modalidades.Filtro;
using Application.DTOs.Modalidades;
using Domain.Commands.Modalidades.Adicionar;
using Domain.Commands.Modalidades.Atualizar;
using Domain.Commands.Modalidades.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Modalidades
{
    public interface IModalidadeService
    {
        Task<FormularioResponse<AdicionarModalidadeCommand>> Adicionar(AdicionarModalidadeRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarModalidadeCommand>> Atualizar(AtualizarModalidadeRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirModalidadeCommand>>> Excluir(ExcluirModalidadeDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ModalidadeFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ModalidadeByCodeDto?> RetornarPorId(Guid id);
    }
}
