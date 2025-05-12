using Domain.Constant;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FusoHorarios.Excluir
{
    public class ExcluirFusoHorarioCommandHandler : IRequestHandler<ExcluirFusoHorarioCommand, List<FormularioResponse<ExcluirFusoHorarioCommand>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly List<FormularioResponse<ExcluirFusoHorarioCommand>> _response = new();

        public ExcluirFusoHorarioCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuratio)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuratio;
        }

        public async Task<List<FormularioResponse<ExcluirFusoHorarioCommand>>> Handle(ExcluirFusoHorarioCommand command, CancellationToken cancellationToken)
        {
            var fusoHorario = await _unitOfWork.FusoHorarioRepository.RetornarFusoHorariosExcluirMassa(command.FiltroBase);

            if (!fusoHorario.Any())
            {
                AddErroNaResposta(command);
                return _response;
            }

            RemoverItensSelecionados(fusoHorario);
            await _unitOfWork.CommitAsync(cancellationToken);

            return _response;
        }

        private void AddErroNaResposta(ExcluirFusoHorarioCommand command)
        {
            var index = 0;
            var response = new FormularioResponse<ExcluirFusoHorarioCommand>(index);
            response.AddError(command.FiltroBase.FiltrarPor ?? "", ErrorMessages.REGISTER_NOT_FOUND_BY_PARAMETER, command.FiltroBase.ValorFiltro ?? "");
            _response.Add(response);
        }

        private void RemoverItensSelecionados(List<FusoHorario> fusoHorarios)
        {
            var index = 0;
            foreach (var fusoHorario in fusoHorarios)
            {

                fusoHorario.ChangeRemoved(true);

                _response.Add(new FormularioResponse<ExcluirFusoHorarioCommand>(index));
                index++;
            }
        }
    }
}