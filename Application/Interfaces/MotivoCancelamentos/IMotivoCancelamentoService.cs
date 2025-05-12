using Application.DTOs.MotivoCancelamentos.Adicionar;
using Application.DTOs.MotivoCancelamentos.Atualizar;
using Application.DTOs.MotivoCancelamentos.Excluir;
using Application.DTOs.MotivoCancelamentos.Filtro;
using Application.DTOs.MotivoCancelamentos;
using Domain.Commands.MotivoCancelamentos.Adicionar;
using Domain.Commands.MotivoCancelamentos.Atualizar;
using Domain.Commands.MotivoCancelamentos.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.MotivoCancelamentos
{
    public interface IMotivoCancelamentoService
    {
        Task<FormularioResponse<AdicionarMotivoCancelamentoCommand>> Adicionar(AdicionarMotivoCancelamentoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarMotivoCancelamentoCommand>> Atualizar(AtualizarMotivoCancelamentoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirMotivoCancelamentoCommand>>> Excluir(ExcluirMotivoCancelamentoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<MotivoCancelamentoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<MotivoCancelamentoByCodeDto?> RetornarPorId(Guid id);
    }
}
