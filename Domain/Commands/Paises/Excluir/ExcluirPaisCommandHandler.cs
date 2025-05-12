using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Paises.Excluir
{
    public class ExcluirPaisCommandHandler : IRequestHandler<ExcluirPaisCommand, List<FormularioResponse<ExcluirPaisCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirPaisCommand>> _response = new();

        public ExcluirPaisCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirPaisCommand>>> Handle(ExcluirPaisCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.PaisRepository.RetornarPaissExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirPaisCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirPaisCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Pais> paises)
        {
            var index = 0;
            foreach (var checklist in paises)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirPaisCommand>(index));
                index++;
            }
        }
    }
}