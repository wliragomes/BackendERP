using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Parametros.Excluir
{
    public class ExcluirParametroCommandHandler : IRequestHandler<ExcluirParametroCommand, List<FormularioResponse<ExcluirParametroCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirParametroCommand>> _response = new();

        public ExcluirParametroCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirParametroCommand>>> Handle(ExcluirParametroCommand command, CancellationToken cancellationToken)
        {
            var parametro = await _unitOfWork.ParametroRepository.RetornarParametrosExcluirMassa(command.FiltroBase);

            if (!parametro.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(parametro);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirParametroCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirParametroCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<Parametro> parametros)
        {
            var index = 0;
            foreach (var parametro in parametros)
            {

                parametro.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirParametroCommand>(index));
                index++;
            }
        }
    }
}