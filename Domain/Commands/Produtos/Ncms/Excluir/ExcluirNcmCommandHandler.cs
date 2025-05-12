using Domain.Constant;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ncms.Excluir
{
    public class ExcluirNcmCommandHandler : IRequestHandler<ExcluirNcmCommand, List<FormularioResponse<ExcluirNcmCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirNcmCommand>> _response = new();

        public ExcluirNcmCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirNcmCommand>>> Handle(ExcluirNcmCommand command, CancellationToken cancellationToken)
        {
            var ncm = await _unitOfWork.NcmRepository.RetornarNcmsExcluirMassa(command.FiltroBase);

            if (!ncm.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(ncm);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirNcmCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirNcmCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Domain.Entities.Produtos.Ncm> ncm)
        {
            var index = 0;
            foreach (var intem in ncm)
            {

                intem.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirNcmCommand>(index));
                index++;
            }
        }
    }
}
