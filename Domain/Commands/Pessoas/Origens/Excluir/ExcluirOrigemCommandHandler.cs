using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Origens.Excluir
{
    public class ExcluirOrigemCommandHandler : IRequestHandler<ExcluirOrigemCommand, List<FormularioResponse<ExcluirOrigemCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirOrigemCommand>> _response = new();

        public ExcluirOrigemCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirOrigemCommand>>> Handle(ExcluirOrigemCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.OrigemRepository.RetornarOrigemsExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirOrigemCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirOrigemCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Origem> origems)
        {
            var index = 0;
            foreach (var checklist in origems)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirOrigemCommand>(index));
                index++;
            }
        }
    }
}