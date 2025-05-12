using Domain.Constant;
using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIpis.Excluir
{
    public class ExcluirCstIpiCommandHandler : IRequestHandler<ExcluirCstIpiCommand, List<FormularioResponse<ExcluirCstIpiCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCstIpiCommand>> _response = new();

        public ExcluirCstIpiCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCstIpiCommand>>> Handle(ExcluirCstIpiCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.CST_IPIRepository.RetornarCST_IPIsExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCstIpiCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCstIpiCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<CstIpi> cst_ipis)
        {
            var index = 0;
            foreach (var checklist in cst_ipis)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCstIpiCommand>(index));
                index++;
            }
        }
    }
}
