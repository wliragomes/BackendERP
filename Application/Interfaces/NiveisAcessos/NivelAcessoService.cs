using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.NiveisAcessos.Adicionar;
using Application.DTOs.NiveisAcessos.Atualizar;
using Application.DTOs.NiveisAcessos.Excluir;
using Application.DTOs.NiveisAcessos.Filtro;
using Application.DTOs.NiveisAcessos;
using Domain.Commands.NiveisAcessos.Adicionar;
using Domain.Commands.NiveisAcessos.Atualizar;
using Domain.Commands.NiveisAcessos.Excluir;

namespace Application.Interfaces.NiveisAcessos
{
    public interface INivelAcessoService
    {
        Task<FormularioResponse<AdicionarNivelAcessoCommand>> Adicionar(AdicionarNivelAcessoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarNivelAcessoCommand>> Atualizar(AtualizarNivelAcessoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirNivelAcessoCommand>>> Excluir(ExcluirNivelAcessoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<NivelAcessoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<NivelAcessoByCodeDto?> RetornarPorId(Guid id);
    }
}
