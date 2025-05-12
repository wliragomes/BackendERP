using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraOrigems.Atualizar
{
    public class AtualizarObraOrigemCommandHandler : IRequestHandler<AtualizarObraOrigemCommand, FormularioResponse<AtualizarObraOrigemCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarObraOrigemCommand> _validator;
        private const int _indice = 0;

        public AtualizarObraOrigemCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarObraOrigemCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarObraOrigemCommand>> Handle(AtualizarObraOrigemCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarObraOrigemCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ObraOrigemUpdate = await _unitOfWork.ObraOrigemRepository.ObterPorId(command.Id);
            ObraOrigemUpdate!.Update(command.Nome);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarObraOrigemCommand(
                command.Id,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
