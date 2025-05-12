using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.ClasseReajustes.Excluir
{
    public class ExcluirClasseReajusteCommandHandler : IRequestHandler<ExcluirClasseReajusteCommand, List<FormularioResponse<ExcluirClasseReajusteCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirClasseReajusteCommand>> _response = new();

        public ExcluirClasseReajusteCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirClasseReajusteCommand>>> Handle(ExcluirClasseReajusteCommand command, CancellationToken cancellationToken)
        {
            var classeReajuste = await _unitOfWork.ClasseReajusteRepository.RetornarClasseReajustesExcluirMassa(command.FiltroBase);

            if (!classeReajuste.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(classeReajuste);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirClasseReajusteCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirClasseReajusteCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.ClasseReajuste> classeReajuste)
        {
            var index = 0;
            foreach (var intem in classeReajuste)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirClasseReajusteCommand>(index));
                index++;
            }
        }
    }
}
