using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Piss.Atualizar
{
    public class AtualizarPisCommandHandler : IRequestHandler<AtualizarPisCommand, FormularioResponse<AtualizarPisCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarPisCommand> _validator;
        private const int _indice = 0;

        public AtualizarPisCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarPisCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarPisCommand>> Handle(AtualizarPisCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarPisCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var PisUpdate = await _unitOfWork.PisRepository.ObterPisPorId(command.Id);
            PisUpdate!.Update(command.Nome, command.PisAmigavel, command.DescontaPis);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarPisCommand(
                command.Id,
                command.Nome,
                command.PisAmigavel,
                command.DescontaPis);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
