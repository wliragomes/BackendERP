using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposCarrocerias.Excluir
{
    public class ExcluirTipoCarroceriaCommandHandler : IRequestHandler<ExcluirTipoCarroceriaCommand, List<FormularioResponse<ExcluirTipoCarroceriaCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirTipoCarroceriaCommand>> _response = new();

        public ExcluirTipoCarroceriaCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirTipoCarroceriaCommand>>> Handle(ExcluirTipoCarroceriaCommand command, CancellationToken cancellationToken)
        {
            var tipoCarroceria = await _unitOfWork.TipoCarroceriaRepository.RetornarTiposCarroceriasExcluirMassa(command.FiltroBase);

            if (!tipoCarroceria.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(tipoCarroceria);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirTipoCarroceriaCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirTipoCarroceriaCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<TipoCarroceria> tiposCarrocerias)
        {
            var index = 0;
            foreach (var tipoCarroceria in tiposCarrocerias)
            {

                tipoCarroceria.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirTipoCarroceriaCommand>(index));
                index++;
            }
        }
    }
}