using Application.DTOs.FaturaTemporarias;

namespace Application.Interfaces.Queries
{
    public interface IFaturaTemporariaQuery
    {
        Task<FaturaTemporariaByCodeDto?> RetornarPorId(Guid id);
    }
}
