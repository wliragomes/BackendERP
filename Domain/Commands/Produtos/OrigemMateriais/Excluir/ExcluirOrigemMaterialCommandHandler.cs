using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.OrigemMateriais.Excluir
{
    public class ExcluirOrigemMaterialCommandHandler : IRequestHandler<ExcluirOrigemMaterialCommand, List<FormularioResponse<ExcluirOrigemMaterialCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirOrigemMaterialCommand>> _response = new();

        public ExcluirOrigemMaterialCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirOrigemMaterialCommand>>> Handle(ExcluirOrigemMaterialCommand command, CancellationToken cancellationToken)
        {
            var origemmaterial = await _unitOfWork.OrigemMaterialRepository.RetornarOrigemMateriaisExcluirMassa(command.FiltroBase);

            if (!origemmaterial.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(origemmaterial);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirOrigemMaterialCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirOrigemMaterialCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.OrigemMaterial> origemmaterial)
        {
            var index = 0;
            foreach (var intem in origemmaterial)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirOrigemMaterialCommand>(index));
                index++;
            }
        }
    }
}
