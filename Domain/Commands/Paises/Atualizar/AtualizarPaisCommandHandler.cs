using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Paises.Atualizar
{
    public class AtualizarPaisCommandHandler : IRequestHandler<AtualizarPaisCommand, FormularioResponse<AtualizarPaisCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPaisCommand> _validator;
        private const int _indice = 0;

        public AtualizarPaisCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarPaisCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarPaisCommand>> Handle(AtualizarPaisCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPaisCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var PaisUpdate = await _unitOfWork.PaisRepository.ObterPorId(command.Id);
            PaisUpdate!.Update(command.Nome, command.IdFusoHorario, command.IdDdi, command.IdMoedaPrincipal);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarPaisCommand(
                command.Id,
                command.Nome,
                command.IdFusoHorario,
                command.IdDdi,
                command.IdMoedaPrincipal);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
