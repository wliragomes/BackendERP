using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Paises.Filtro;
using Application.DTOs.Paises;
using Application.DTOs.Paises.Excluir;
using Application.DTOs.Paises.Atualizar;
using Domain.Commands.Paises.Adicionar;
using Domain.Commands.Paises.Atualizar;
using Domain.Commands.Paises.Excluir;
using Application.DTOs.Paises.Adicionar;

namespace Application.Interfaces.Paises
{
    public interface IPaisService
    {
        Task<FormularioResponse<AdicionarPaisCommand>> Adicionar(AdicionarPaisRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarPaisCommand>> Atualizar(AtualizarPaisRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirPaisCommand>>> Excluir(ExcluirPaisDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<PaginacaoResponse<PaisFilterDto>> RetornarPaginacaoDapper(DapperPaginacaoRequest paginacaoRequest);
        Task<PaisByCodeDto?> RetornarPorId(Guid id);
    }
}
