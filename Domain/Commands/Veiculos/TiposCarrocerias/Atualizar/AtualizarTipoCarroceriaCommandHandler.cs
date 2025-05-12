using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposCarrocerias.Atualizar
{
    public class AtualizarTipoCarroceriaCommandHandler : IRequestHandler<AtualizarTipoCarroceriaCommand, FormularioResponse<AtualizarTipoCarroceriaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarTipoCarroceriaCommand> _validator;
        private const int _indice = 0;

        public AtualizarTipoCarroceriaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarTipoCarroceriaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarTipoCarroceriaCommand>> Handle(AtualizarTipoCarroceriaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarTipoCarroceriaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var TipoCarroceriaUpdate = await _unitOfWork.TipoCarroceriaRepository.ObterPorId(command.Id);
            TipoCarroceriaUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarTipoCarroceriaCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
