using Application.DTOs.CepsBloqueados.Adicionar;
using Application.DTOs.CepsBloqueados.Atualizar;
using Application.DTOs.CepsBloqueados.Excluir;
using Application.DTOs.CepsBloqueados.Filtro;
using Application.DTOs.CepsBloqueados;
using Domain.Commands.CepsBloqueados.Adicionar;
using Domain.Commands.CepsBloqueados.Atualizar;
using Domain.Commands.CepsBloqueados.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.CepsBloqueados
{
    public interface ICepBloqueadoService
    {
        Task<FormularioResponse<AdicionarCepBloqueadoCommand>> Adicionar(AdicionarCepBloqueadoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarCepBloqueadoCommand>> Atualizar(AtualizarCepBloqueadoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirCepBloqueadoCommand>>> Excluir(ExcluirCepBloqueadoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<CepBloqueadoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<CepBloqueadoByCodeDto?> RetornarPorId(Guid id);
    }
}
