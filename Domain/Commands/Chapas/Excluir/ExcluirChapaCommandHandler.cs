using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Chapas.Excluir
{
    public class ExcluirChapaCommandHandler : IRequestHandler<ExcluirChapaCommand, List<FormularioResponse<ExcluirChapaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirChapaCommand>> _response = new();

        public ExcluirChapaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirChapaCommand>>> Handle(ExcluirChapaCommand command, CancellationToken cancellationToken)
        {
            var chapa = await _unitOfWork.ChapaRepository.RetornarChapasExcluirMassa(command.FiltroBase);

            if (!chapa.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(chapa);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirChapaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirChapaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Chapa> chapas)
        {
            var index = 0;
            foreach (var chapa in chapas)
            {

                chapa.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirChapaCommand>(index));
                index++;
            }
        }
    }
}