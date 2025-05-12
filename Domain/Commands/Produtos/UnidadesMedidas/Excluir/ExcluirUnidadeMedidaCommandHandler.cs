using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.UnidadesMedidas.Excluir
{
    public class ExcluirUnidadeMedidaCommandHandler : IRequestHandler<ExcluirUnidadeMedidaCommand, List<FormularioResponse<ExcluirUnidadeMedidaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirUnidadeMedidaCommand>> _response = new();

        public ExcluirUnidadeMedidaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirUnidadeMedidaCommand>>> Handle(ExcluirUnidadeMedidaCommand command, CancellationToken cancellationToken)
        {
            var unidademedida = await _unitOfWork.UnidadeMedidaRepository.RetornarUnidadesMedidasMassa(command.FiltroBase);

            if (!unidademedida.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(unidademedida);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirUnidadeMedidaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirUnidadeMedidaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.UnidadeMedida> unidademedida)
        {
            var index = 0;
            foreach (var intem in unidademedida)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirUnidadeMedidaCommand>(index));
                index++;
            }
        }
    }
}
