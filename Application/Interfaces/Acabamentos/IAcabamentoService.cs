using Application.DTOs.Acabamentos.Adicionar;
using Application.DTOs.Acabamentos.Atualizar;
using Application.DTOs.Acabamentos.Excluir;
using Application.DTOs.Acabamentos.Filtro;
using Application.DTOs.Acabamentos;
using Domain.Commands.Acabamentos.Adicionar;
using Domain.Commands.Acabamentos.Atualizar;
using Domain.Commands.Acabamentos.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Acabamentos
{
    public interface IAcabamentoService
    {
        Task<FormularioResponse<AdicionarAcabamentoCommand>> Adicionar(AdicionarAcabamentoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarAcabamentoCommand>> Atualizar(AtualizarAcabamentoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirAcabamentoCommand>>> Excluir(ExcluirAcabamentoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<AcabamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<AcabamentoByCodeDto?> RetornarPorId(Guid id);
    }
}
