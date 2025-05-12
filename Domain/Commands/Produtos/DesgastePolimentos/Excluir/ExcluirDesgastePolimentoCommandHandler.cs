using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.DesgastePolimentos.Excluir
{
    public class ExcluirDesgastePolimentoCommandHandler : IRequestHandler<ExcluirDesgastePolimentoCommand, List<FormularioResponse<ExcluirDesgastePolimentoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirDesgastePolimentoCommand>> _response = new();

        public ExcluirDesgastePolimentoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirDesgastePolimentoCommand>>> Handle(ExcluirDesgastePolimentoCommand command, CancellationToken cancellationToken)
        {
            var desgastePolimento = await _unitOfWork.DesgastePolimentoRepository.RetornarDesgastePolimentoExcluirMassa(command.FiltroBase);

            if (!desgastePolimento.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(desgastePolimento);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirDesgastePolimentoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirDesgastePolimentoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.DesgastePolimento> desgastePolimento)
        {
            var index = 0;
            foreach (var intem in desgastePolimento)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirDesgastePolimentoCommand>(index));
                index++;
            }
        }
    }
}
