using Application.DTOs.NFes;

namespace Application.Interfaces.NFes
{
    public interface INFeService
    {
        Task<NFeResponseDto> EmitirNFe(Guid idFatura, CancellationToken cancellationToken);
    }
}
