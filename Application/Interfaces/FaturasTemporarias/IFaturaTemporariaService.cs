using Application.DTOs.FaturaTemporarias.Adicionar;
using Application.DTOs.FaturaTemporarias.Excluir;
using Application.DTOs.FaturaTemporarias;
using SharedKernel.SharedObjects;
using Domain.Commands.FaturaTemporarias.Excluir;
using Domain.Commands.FaturaTemporarias.Adicionar;

namespace Application.Interfaces.FaturaTemporarias
{
    public interface IFaturaTemporariaService
    {
        Task<FormularioResponse<AdicionarFaturaTemporariaCommand>> Adicionar(AdicionarFaturaTemporariaRequestDto dtos, CancellationToken cancellationToken);
        Task<List<FormularioResponse<ExcluirFaturaTemporariaCommand>>> Excluir(ExcluirFaturaTemporariaDto dtos, CancellationToken cancellationToken);
        Task<FaturaTemporariaByCodeDto?> RetornarPorId(Guid id);
    }
}
