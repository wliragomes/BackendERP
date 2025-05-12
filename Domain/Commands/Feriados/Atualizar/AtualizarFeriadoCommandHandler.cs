using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Feriados.Atualizar
{
    public class AtualizarFeriadoCommandHandler : IRequestHandler<AtualizarFeriadoCommand, FormularioResponse<AtualizarFeriadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFeriadoCommand> _validator;
        private const int _indice = 0;

        public AtualizarFeriadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFeriadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFeriadoCommand>> Handle(AtualizarFeriadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFeriadoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var FeriadoUpdate = await _unitOfWork.FeriadoRepository.ObterPorId(command.Id);
            FeriadoUpdate!.Update(command.Nome, command.Data);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarFeriadoCommand(
                command.Id,
                command.Nome,
                command.Data);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
