using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cargos.Atualizar
{
    public class AtualizarCargoCommandHandler : IRequestHandler<AtualizarCargoCommand, FormularioResponse<AtualizarCargoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCargoCommand> _validator;
        private const int _indice = 0;

        public AtualizarCargoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCargoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCargoCommand>> Handle(AtualizarCargoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCargoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CargoUpdate = await _unitOfWork.CargoRepository.ObterPorId(command.Id);
            CargoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCargoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
