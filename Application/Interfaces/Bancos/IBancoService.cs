using Application.DTOs.Bancos.Adicionar;
using Application.DTOs.Bancos.Atualizar;
using Application.DTOs.Bancos.Excluir;
using Application.DTOs.Bancos.Filtro;
using Application.DTOs.Bancos;
using Domain.Commands.Bancos.Adicionar;
using Domain.Commands.Bancos.Atualizar;
using Domain.Commands.Bancos.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Bancos
{
    public interface IBancoService
    {
        Task<FormularioResponse<AdicionarBancoCommand>> Adicionar(AdicionarBancoRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarBancoCommand>> Atualizar(AtualizarBancoRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirBancoCommand>>> Excluir(ExcluirBancoDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<BancoFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<BancoByCodeDto?> RetornarPorId(Guid id);
    }
}
