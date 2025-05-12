using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposRodados.Excluir
{
    public class ExcluirTipoRodadoCommandHandler : IRequestHandler<ExcluirTipoRodadoCommand, List<FormularioResponse<ExcluirTipoRodadoCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirTipoRodadoCommand>> _response = new();

        public ExcluirTipoRodadoCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirTipoRodadoCommand>>> Handle(ExcluirTipoRodadoCommand command, CancellationToken cancellationToken)
        {
            var tipoCarroceria = await _unitOfWork.TipoRodadoRepository.RetornarTiposRodadosExcluirMassa(command.FiltroBase);

            if (!tipoCarroceria.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(tipoCarroceria);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirTipoRodadoCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirTipoRodadoCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<TipoRodado> tiposCarrocerias)
        {
            var index = 0;
            foreach (var tipoCarroceria in tiposCarrocerias)
            {

                tipoCarroceria.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirTipoRodadoCommand>(index));
                index++;
            }
        }
    }
}