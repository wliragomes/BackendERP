using Application.DTOs.ContasBancarias.Adicionar;
using Application.DTOs.ContasBancarias.Atualizar;
using Application.DTOs.ContasBancarias.Excluir;
using Application.DTOs.ContasBancarias.Filtro;
using Application.DTOs.ContasBancarias;
using Domain.Commands.ContasBancarias.Adicionar;
using Domain.Commands.ContasBancarias.Atualizar;
using Domain.Commands.ContasBancarias.Excluir;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;

namespace Application.Interfaces.ContasBancarias
{
    public interface IContaBancariaService
    {
        Task<FormularioResponse<AdicionarContaBancariaCommand>> Adicionar(AdicionarContaBancariaRequestDto dtos, CancellationToken cancellationToken);
        Task<FormularioResponse<AtualizarContaBancariaCommand>> Atualizar(AtualizarContaBancariaRequestDto dto, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirContaBancariaCommand>>> Excluir(ExcluirContaBancariaDto dtos, CancellationToken cancellationToken);
        Task<PaginacaoResponse<ContaBancariaFilterDto>> RetornarPaginacao(PaginacaoRequest paginacaoRequest);
        Task<ContaBancariaByCodeDto?> RetornarPorId(Guid id);
    }
}
