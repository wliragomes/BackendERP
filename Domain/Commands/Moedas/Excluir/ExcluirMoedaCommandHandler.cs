using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Moedas.Excluir
{
    public class ExcluirMoedaCommandHandler : IRequestHandler<ExcluirMoedaCommand, List<FormularioResponse<ExcluirMoedaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirMoedaCommand>> _response = new();

        public ExcluirMoedaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirMoedaCommand>>> Handle(ExcluirMoedaCommand command, CancellationToken cancellationToken)
        {
            var moeda = await _unitOfWork.MoedaRepository.RetornarMoedasExcluirMassa(command.FiltroBase);

            if (!moeda.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(moeda);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirMoedaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirMoedaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Moeda> moedas)
        {
            var index = 0;
            foreach (var moeda in moedas)
            {

                moeda.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirMoedaCommand>(index));
                index++;
            }
        }
    }
}