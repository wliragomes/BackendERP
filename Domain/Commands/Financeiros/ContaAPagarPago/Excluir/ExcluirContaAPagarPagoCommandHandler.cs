using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasAPagarPago.Excluir
{
    public class ExcluirContaAPagarPagoCommandHandler : IRequestHandler<ExcluirContaAPagarPagoCommand, List<FormularioResponse<ExcluirContaAPagarPagoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirContaAPagarPagoCommand>> _response = new();

        public ExcluirContaAPagarPagoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirContaAPagarPagoCommand>>> Handle(ExcluirContaAPagarPagoCommand command, CancellationToken cancellationToken)
        {
            var contaAPagarPago = await _unitOfWork.ContaAPagarPagoRepository.RetornarContasAPagarPagoExcluirMassa(command.FiltroBase);

            if (!contaAPagarPago.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(contaAPagarPago);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirContaAPagarPagoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirContaAPagarPagoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<ContaAPagarPago> contasAPagarPago)
        {
            var index = 0;
            foreach (var contaAPagarPago in contasAPagarPago)
            {

                contaAPagarPago.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirContaAPagarPagoCommand>(index));
                index++;
            }
        }
    }
}