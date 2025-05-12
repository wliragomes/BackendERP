using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Estados.Atualizar
{
    public class AtualizarEstadoCommandHandler : IRequestHandler<AtualizarEstadoCommand, FormularioResponse<AtualizarEstadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarEstadoCommand> _validator;
        private const int _indice = 0;

        public AtualizarEstadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarEstadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarEstadoCommand>> Handle(AtualizarEstadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarEstadoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var EstadoUpdate = await _unitOfWork.EstadoRepository.ObterPorId(command.Id);
            EstadoUpdate!.Update(command.IdPais, command.Nome!, command.Sigla!, command.CodIBGE, command.AliquotaIcmsInterestadual, command.AliquotaIcmsInterna, command.AliquotaIcmsDiferenca);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarEstadoCommand(
                EstadoUpdate.Id,
                command.IdPais,
                command.Nome,
                command.Sigla,
                command.CodIBGE,
                command.AliquotaIcmsInterestadual,
                command.AliquotaIcmsInterna,
                command.AliquotaIcmsDiferenca);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
