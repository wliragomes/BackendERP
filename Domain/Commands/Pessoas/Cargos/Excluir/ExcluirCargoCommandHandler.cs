using Domain.Constant;
using Domain.Entities.Contatos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cargos.Excluir
{
    public class ExcluirCargoCommandHandler : IRequestHandler<ExcluirCargoCommand, List<FormularioResponse<ExcluirCargoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCargoCommand>> _response = new();

        public ExcluirCargoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCargoCommand>>> Handle(ExcluirCargoCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.CargoRepository.RetornarCargosExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCargoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCargoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Cargo> cargos)
        {
            var index = 0;
            foreach (var checklist in cargos)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCargoCommand>(index));
                index++;
            }
        }
    }
}