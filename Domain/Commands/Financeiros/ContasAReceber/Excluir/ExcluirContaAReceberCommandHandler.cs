using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAReceber.Excluir
{
    public class ExcluirContaAReceberCommandHandler : IRequestHandler<ExcluirContaAReceberCommand, List<FormularioResponse<ExcluirContaAReceberCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirContaAReceberCommand>> _response = new();

        public ExcluirContaAReceberCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirContaAReceberCommand>>> Handle(ExcluirContaAReceberCommand command, CancellationToken cancellationToken)
        {
            var contaAReceber = await _unitOfWork.ContaAReceberRepository.RetornarContasAReceberExcluirMassa(command.FiltroBase);

            if (!contaAReceber.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(contaAReceber);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirContaAReceberCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirContaAReceberCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ContaAReceber> contasAReceber)
        {
            var index = 0;
            foreach (var contaAReceber in contasAReceber)
            {

                contaAReceber.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirContaAReceberCommand>(index));
                index++;
            }
        }
    }
}