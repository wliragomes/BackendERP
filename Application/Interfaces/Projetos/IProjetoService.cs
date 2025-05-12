using Application.DTOs.Projetos.Adicionar;
using Application.DTOs.Projetos.Atualizar;
using Application.DTOs.Projetos.Excluir;
using Application.DTOs.Projetos.Filtro;
using Application.DTOs.Projetos;
using Domain.Commands.Projetos.Adicionar;
using Domain.Commands.Projetos.Atualizar;
using Domain.Commands.Projetos.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Projetos
{
    public interface IProjetoService
    {
        Task<FormularioResponse<AdicionarProjetoCommand>> Adicionar(AdicionarProjetoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarProjetoCommand>> Atualizar(AtualizarProjetoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirProjetoCommand>>> Excluir(ExcluirProjetoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ProjetoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ProjetoByCodeDto?> RetornarPorId(Guid id);
    }
}
