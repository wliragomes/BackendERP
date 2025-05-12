using Domain.Constant;
using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.CstIcmss.Excluir
{
    public class ExcluirCstIcmsCommandHandler : IRequestHandler<ExcluirCstIcmsCommand, List<FormularioResponse<ExcluirCstIcmsCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirCstIcmsCommand>> _response = new();

        public ExcluirCstIcmsCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirCstIcmsCommand>>> Handle(ExcluirCstIcmsCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.CST_ICMSRepository.RetornarCST_ICMSsExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirCstIcmsCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirCstIcmsCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<CST_ICMS> cst_icmss)
        {
            var index = 0;
            foreach (var checklist in cst_icmss)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirCstIcmsCommand>(index));
                index++;
            }
        }
    }
}