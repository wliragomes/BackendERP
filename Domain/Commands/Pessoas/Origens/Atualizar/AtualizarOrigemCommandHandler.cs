using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Origens.Atualizar
{
    public class AtualizarOrigemCommandHandler : IRequestHandler<AtualizarOrigemCommand, FormularioResponse<AtualizarOrigemCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarOrigemCommand> _validator;
        private const int _indice = 0;

        public AtualizarOrigemCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarOrigemCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarOrigemCommand>> Handle(AtualizarOrigemCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarOrigemCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var OrigemUpdate = await _unitOfWork.OrigemRepository.ObterPorId(command.Id);
            OrigemUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarOrigemCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
