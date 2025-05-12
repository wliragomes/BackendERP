using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Prateleiras.Atualizar
{
    public class AtualizarPrateleiraCommandHandler : IRequestHandler<AtualizarPrateleiraCommand, FormularioResponse<AtualizarPrateleiraCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPrateleiraCommand> _validator;
        private const int _indice = 0;

        public AtualizarPrateleiraCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarPrateleiraCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarPrateleiraCommand>> Handle(AtualizarPrateleiraCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPrateleiraCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var PrateleiraUpdate = await _unitOfWork.PrateleiraRepository.ObterPorId(command.Id);
            PrateleiraUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarPrateleiraCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
