using Application.DTOs.NFes;

namespace Application.Interfaces.NFes
{
    public interface INFeProcessor
    {
        Task<NFeResponseDto> EmitirNFe(Guid idFatura, CancellationToken cancellationToken);
    }
}
