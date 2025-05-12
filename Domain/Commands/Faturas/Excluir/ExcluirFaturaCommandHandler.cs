using Domain.Constant;
using Domain.Entities.Faturas;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Faturas.Excluir
{
    public class ExcluirFaturaCommandHandler : IRequestHandler<ExcluirFaturaCommand, List<FormularioResponse<ExcluirFaturaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFaturaCommand>> _response = new();

        public ExcluirFaturaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFaturaCommand>>> Handle(ExcluirFaturaCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.FaturaRepository.RetornarFaturasExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFaturaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFaturaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Fatura> faturas)
        {
            var index = 0;
            foreach (var cidade in faturas)
            {

                cidade.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFaturaCommand>(index));
                index++;
            }
        }
    }
}