using Application.DTOs.NFes;
using Application.Interfaces.NFes;

namespace Application.Services.NFes
{
    public class NFeService : INFeService
    {
        private readonly INFeProcessor _nfeProcessor;

        public NFeService(INFeProcessor nfeProcessor)
        {
            _nfeProcessor = nfeProcessor;
        }

        public async Task<NFeResponseDto> EmitirNFe(Guid idFatura, CancellationToken cancellationToken)
        {
            return await _nfeProcessor.EmitirNFe(idFatura, cancellationToken);
        }
    }
}
