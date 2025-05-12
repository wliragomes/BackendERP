using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagar.Excluir
{
    public class ExcluirContaAPagarCommandHandler : IRequestHandler<ExcluirContaAPagarCommand, List<FormularioResponse<ExcluirContaAPagarCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirContaAPagarCommand>> _response = new();

        public ExcluirContaAPagarCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirContaAPagarCommand>>> Handle(ExcluirContaAPagarCommand command, CancellationToken cancellationToken)
        {
            var contaAPagar = await _unitOfWork.ContaAPagarRepository.RetornarContasAPagarExcluirMassa(command.FiltroBase);

            if (!contaAPagar.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(contaAPagar);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirContaAPagarCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirContaAPagarCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ContaAPagar> contasAPagar)
        {
            var index = 0;
            foreach (var contaAPagar in contasAPagar)
            {

                contaAPagar.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirContaAPagarCommand>(index));
                index++;
            }
        }
    }
}