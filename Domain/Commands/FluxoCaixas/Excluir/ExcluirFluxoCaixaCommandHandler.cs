using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FluxoCaixas.Excluir
{
    public class ExcluirFluxoCaixaCommandHandler : IRequestHandler<ExcluirFluxoCaixaCommand, List<FormularioResponse<ExcluirFluxoCaixaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFluxoCaixaCommand>> _response = new();

        public ExcluirFluxoCaixaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFluxoCaixaCommand>>> Handle(ExcluirFluxoCaixaCommand command, CancellationToken cancellationToken)
        {
            var fluxoCaixa = await _unitOfWork.FluxoCaixaRepository.RetornarFluxoCaixasExcluirMassa(command.FiltroBase);

            if (!fluxoCaixa.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(fluxoCaixa);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFluxoCaixaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFluxoCaixaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<FluxoCaixa> fluxoCaixas)
        {
            var index = 0;
            foreach (var fluxoCaixa in fluxoCaixas)
            {

                fluxoCaixa.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFluxoCaixaCommand>(index));
                index++;
            }
        }
    }
}