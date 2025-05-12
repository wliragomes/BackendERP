using Application.DTOs.FaturaParametros.Adicionar;
using Application.DTOs.FaturaParametros.Atualizar;
using Application.DTOs.FaturaParametros.Excluir;
using Application.DTOs.FaturaParametros.Filtro;
using Application.DTOs.FaturaParametros;
using Domain.Commands.FaturaParametros.Adicionar;
using Domain.Commands.FaturaParametros.Atualizar;
using Domain.Commands.FaturaParametros.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.FaturaParametros
{
    public interface IFaturaParametroService
    {
        Task<FormularioResponse<AdicionarFaturaParametroCommand>> Adicionar(AdicionarFaturaParametroRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarFaturaParametroCommand>> Atualizar(AtualizarFaturaParametroRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFaturaParametroCommand>>> Excluir(ExcluirFaturaParametroDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<FaturaParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<FaturaParametroByCodeDto?> RetornarPorId(Guid id);
    }
}
