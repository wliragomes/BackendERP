using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.PlanosDeContas.Excluir
{
    public class ExcluirPlanoDeContasCommandHandler : IRequestHandler<ExcluirPlanoDeContasCommand, List<FormularioResponse<ExcluirPlanoDeContasCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirPlanoDeContasCommand>> _response = new();

        public ExcluirPlanoDeContasCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirPlanoDeContasCommand>>> Handle(ExcluirPlanoDeContasCommand command, CancellationToken cancellationToken)
        {
            var planoDeContas = await _unitOfWork.PlanoDeContasRepository.RetornarPlanosDeContasExcluirMassa(command.FiltroBase);

            if (!planoDeContas.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(planoDeContas);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirPlanoDeContasCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirPlanoDeContasCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<PlanoDeContas> planosDeContas)
        {
            var index = 0;
            foreach (var planoDeContas in planosDeContas)
            {

                planoDeContas.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirPlanoDeContasCommand>(index));
                index++;
            }
        }
    }
}