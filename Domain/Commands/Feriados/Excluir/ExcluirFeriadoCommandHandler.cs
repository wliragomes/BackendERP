using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Feriados.Excluir
{
    public class ExcluirFeriadoCommandHandler : IRequestHandler<ExcluirFeriadoCommand, List<FormularioResponse<ExcluirFeriadoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFeriadoCommand>> _response = new();

        public ExcluirFeriadoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFeriadoCommand>>> Handle(ExcluirFeriadoCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.FeriadoRepository.RetornarFeriadosExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFeriadoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFeriadoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Feriado> feriados)
        {
            var index = 0;
            foreach (var checklist in feriados)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFeriadoCommand>(index));
                index++;
            }
        }
    }
}
