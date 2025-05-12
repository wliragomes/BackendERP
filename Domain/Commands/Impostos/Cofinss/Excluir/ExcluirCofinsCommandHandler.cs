using Domain.Constant;
using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Cofinss.Excluir
{
    public class ExcluirCofinsCommandHandler : IRequestHandler<ExcluirCofinsCommand, List<FormularioResponse<ExcluirCofinsCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCofinsCommand>> _response = new();

        public ExcluirCofinsCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCofinsCommand>>> Handle(ExcluirCofinsCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.CofinsRepository.RetornarCofinssExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCofinsCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCofinsCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Cofins> cofins)
        {
            var index = 0;
            foreach (var checklist in cofins)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCofinsCommand>(index));
                index++;
            }
        }
    }
}