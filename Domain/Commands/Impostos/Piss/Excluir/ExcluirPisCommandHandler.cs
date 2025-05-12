using Domain.Constant;
using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Piss.Excluir
{
    public class ExcluirPisCommandHandler : IRequestHandler<ExcluirPisCommand, List<FormularioResponse<ExcluirPisCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirPisCommand>> _response = new();

        public ExcluirPisCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirPisCommand>>> Handle(ExcluirPisCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.PisRepository.RetornarPissExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirPisCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirPisCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Pis> pis)
        {
            var index = 0;
            foreach (var checklist in pis)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirPisCommand>(index));
                index++;
            }
        }
    }
}