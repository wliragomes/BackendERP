using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasProjetos.Atualizar
{
    public class AtualizarObraProjetoCommandHandler : IRequestHandler<AtualizarObraProjetoCommand, FormularioResponse<AtualizarObraProjetoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarObraProjetoCommand> _validator;
        private const int _indice = 0;

        public AtualizarObraProjetoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarObraProjetoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarObraProjetoCommand>> Handle(AtualizarObraProjetoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarObraProjetoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var ObraProjetoUpdate = await _unitOfWork.ObraProjetoRepository.ObterPorId(command.Id);
            ObraProjetoUpdate!.Update(command.Nome);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarObraProjetoCommand(
                command.Id,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
