using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Estados.Excluir
{
    public class ExcluirEstadoCommandHandler : IRequestHandler<ExcluirEstadoCommand, List<FormularioResponse<ExcluirEstadoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirEstadoCommand>> _response = new();

        public ExcluirEstadoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirEstadoCommand>>> Handle(ExcluirEstadoCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.EstadoRepository.RetornarEstadosExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirEstadoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirEstadoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Estado> estados)
        {
            var index = 0;
            foreach (var estado in estados)
            {

                estado.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirEstadoCommand>(index));
                index++;
            }
        }
    }
}