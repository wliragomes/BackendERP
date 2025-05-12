using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObraFases.Atualizar
{
    public class AtualizarObraFaseCommandHandler : IRequestHandler<AtualizarObraFaseCommand, FormularioResponse<AtualizarObraFaseCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarObraFaseCommand> _validator;
        private const int _indice = 0;

        public AtualizarObraFaseCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarObraFaseCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarObraFaseCommand>> Handle(AtualizarObraFaseCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarObraFaseCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ObraFaseUpdate = await _unitOfWork.ObraFaseRepository.ObterPorId(command.Id);
            ObraFaseUpdate!.Update(command.Nome);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarObraFaseCommand(
                command.Id,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
