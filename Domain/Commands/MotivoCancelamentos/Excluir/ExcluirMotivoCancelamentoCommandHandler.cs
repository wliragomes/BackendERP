using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MotivoCancelamentos.Excluir
{
    public class ExcluirMotivoCancelamentoCommandHandler : IRequestHandler<ExcluirMotivoCancelamentoCommand, List<FormularioResponse<ExcluirMotivoCancelamentoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirMotivoCancelamentoCommand>> _response = new();

        public ExcluirMotivoCancelamentoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirMotivoCancelamentoCommand>>> Handle(ExcluirMotivoCancelamentoCommand command, CancellationToken cancellationToken)
        {
            var motivoCancelamento = await _unitOfWork.MotivoCancelamentoRepository.RetornarMotivoCancelamentosExcluirMassa(command.FiltroBase);

            if (!motivoCancelamento.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(motivoCancelamento);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirMotivoCancelamentoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirMotivoCancelamentoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<MotivoCancelamento> motivoCancelamentos)
        {
            var index = 0;
            foreach (var motivoCancelamento in motivoCancelamentos)
            {

                motivoCancelamento.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirMotivoCancelamentoCommand>(index));
                index++;
            }
        }
    }
}