using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Cartoes.Atualizar
{
    public class AtualizarCartaoCommandHandler : IRequestHandler<AtualizarCartaoCommand, FormularioResponse<AtualizarCartaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCartaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarCartaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCartaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCartaoCommand>> Handle(AtualizarCartaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCartaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CartaoUpdate = await _unitOfWork.CartaoRepository.ObterPorId(command.Id);
            CartaoUpdate!.Update(command.Nome);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCartaoCommand(
                command.Id,
                command.Nome);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
