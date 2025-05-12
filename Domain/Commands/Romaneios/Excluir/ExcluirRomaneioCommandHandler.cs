using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Romaneios.Excluir
{
    public class ExcluirRomaneioCommandHandler : IRequestHandler<ExcluirRomaneioCommand, List<FormularioResponse<ExcluirRomaneioCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirRomaneioCommand>> _response = new();

        public ExcluirRomaneioCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirRomaneioCommand>>> Handle(ExcluirRomaneioCommand command, CancellationToken cancellationToken)
        {
            var romaneio = await _unitOfWork.RomaneioRepository.RetornarRomaneiosExcluirMassa(command.FiltroBase);

            if (!romaneio.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(romaneio);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirRomaneioCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirRomaneioCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Romaneio> romaneios)
        {
            var index = 0;
            foreach (var romaneio in romaneios)
            {

                romaneio.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirRomaneioCommand>(index));
                index++;
            }
        }
    }
}