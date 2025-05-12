using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.FusoHorarios.Atualizar
{
    public class AtualizarFusoHorarioCommandHandler : IRequestHandler<AtualizarFusoHorarioCommand, FormularioResponse<AtualizarFusoHorarioCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFusoHorarioCommand> _validator;
        private const int _indice = 0;

        public AtualizarFusoHorarioCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFusoHorarioCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFusoHorarioCommand>> Handle(AtualizarFusoHorarioCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFusoHorarioCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var FusoHorarioUpdate = await _unitOfWork.FusoHorarioRepository.ObterPorId(command.Id);
            FusoHorarioUpdate!.Update(command.NumeroFusoHorario);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarFusoHorarioCommand(
                command.Id,                
                command.NumeroFusoHorario);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
