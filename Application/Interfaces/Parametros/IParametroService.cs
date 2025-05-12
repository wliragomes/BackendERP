using Application.DTOs.Parametros.Adicionar;
using Application.DTOs.Parametros.Atualizar;
using Application.DTOs.Parametros.Excluir;
using Application.DTOs.Parametros.Filtro;
using Application.DTOs.Parametros;
using Domain.Commands.Parametros.Adicionar;
using Domain.Commands.Parametros.Atualizar;
using Domain.Commands.Parametros.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.Parametros
{
    public interface IParametroService
    {
        Task<FormularioResponse<AdicionarParametroCommand>> Adicionar(AdicionarParametroRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarParametroCommand>> Atualizar(AtualizarParametroRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirParametroCommand>>> Excluir(ExcluirParametroDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ParametroFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<ParametroMedidaDto>> RetornarParametroMedida(PaginacaoRequest paginacaoRequest);
        Task<ParametroByCodeDto?> RetornarPorId(Guid id);
    }
}
