using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.RegimeTributarios.Atualizar
{
    public class AtualizarRegimeTributarioCommandHandler : IRequestHandler<AtualizarRegimeTributarioCommand, FormularioResponse<AtualizarRegimeTributarioCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarRegimeTributarioCommand> _validator;
        private const int _indice = 0;

        public AtualizarRegimeTributarioCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarRegimeTributarioCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarRegimeTributarioCommand>> Handle(AtualizarRegimeTributarioCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarRegimeTributarioCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var RegimeTributarioUpdate = await _unitOfWork.RegimeTributarioRepository.ObterPorId(command.Id);
            RegimeTributarioUpdate!.Update(command.Nome, command.ValorPis, command.ValorCofins);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarRegimeTributarioCommand(
                command.Id,
                command.Nome,
                command.ValorPis,
                command.ValorCofins);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
