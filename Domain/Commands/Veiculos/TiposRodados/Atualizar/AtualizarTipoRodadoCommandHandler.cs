using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposRodados.Atualizar
{
    public class AtualizarTipoRodadoCommandHandler : IRequestHandler<AtualizarTipoRodadoCommand, FormularioResponse<AtualizarTipoRodadoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarTipoRodadoCommand> _validator;
        private const int _indice = 0;

        public AtualizarTipoRodadoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarTipoRodadoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarTipoRodadoCommand>> Handle(AtualizarTipoRodadoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarTipoRodadoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var TipoRodadoUpdate = await _unitOfWork.TipoRodadoRepository.ObterPorId(command.Id);
            TipoRodadoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarTipoRodadoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
