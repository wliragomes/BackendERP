using Domain.Constant;
using Domain.Entities.Impostos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Excluir
{
    public class ExcluirIcstIcmsOrigemMaterialCommandHandler : IRequestHandler<ExcluirIcstIcmsOrigemMaterialCommand, List<FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>> _response = new();

        public ExcluirIcstIcmsOrigemMaterialCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>>> Handle(ExcluirIcstIcmsOrigemMaterialCommand command, CancellationToken cancellationToken)
        {
            var checklist = await _unitOfWork.CST_ICMS_Origem_MaterialRepository.RetornarCST_ICMS_Origem_MaterialsExcluirMassa(command.FiltroBase);

            if (!checklist.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }
            RemoverItensSelecionados(checklist);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirIcstIcmsOrigemMaterialCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<CstIcmsOrigemMaterial> cst_icms_origem_materials)
        {
            var index = 0;
            foreach (var checklist in cst_icms_origem_materials)
            {

                checklist.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirIcstIcmsOrigemMaterialCommand>(index));
                index++;
            }
        }
    }
}