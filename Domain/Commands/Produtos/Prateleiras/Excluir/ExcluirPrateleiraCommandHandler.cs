using Domain.Constant;
using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Prateleiras.Excluir
{
    public class ExcluirPrateleiraCommandHandler : IRequestHandler<ExcluirPrateleiraCommand, List<FormularioResponse<ExcluirPrateleiraCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirPrateleiraCommand>> _response = new();

        public ExcluirPrateleiraCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirPrateleiraCommand>>> Handle(ExcluirPrateleiraCommand command, CancellationToken cancellationToken)
        {
            var prateleira = await _unitOfWork.PrateleiraRepository.RetornarPrateleirasExcluirMassa(command.FiltroBase);

            if (!prateleira.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(prateleira);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirPrateleiraCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirPrateleiraCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Prateleira> prateleira)
        {
            var index = 0;
            foreach (var intem in prateleira)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirPrateleiraCommand>(index));
                index++;
            }
        }
    }
}
