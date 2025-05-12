using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Chapas.Atualizar
{
    public class AtualizarChapaCommandHandler : IRequestHandler<AtualizarChapaCommand, FormularioResponse<AtualizarChapaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarChapaCommand> _validator;
        private const int _indice = 0;

        public AtualizarChapaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarChapaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarChapaCommand>> Handle(AtualizarChapaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarChapaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ChapaUpdate = await _unitOfWork.ChapaRepository.ObterPorId(command.Id);
            ChapaUpdate!.Update(command.Descricao, command.Altura, command.Largura);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarChapaCommand(
                command.Id,
                command.Descricao,
                command.Altura,
                command.Largura);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
