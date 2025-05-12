using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.CodigoDDIs.Atualizar
{
    public class AtualizarCodigoDDICommandHandler : IRequestHandler<AtualizarCodigoDDICommand, FormularioResponse<AtualizarCodigoDDICommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCodigoDDICommand> _validator;
        private const int _indice = 0;

        public AtualizarCodigoDDICommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCodigoDDICommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCodigoDDICommand>> Handle(AtualizarCodigoDDICommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCodigoDDICommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CodigoDDIUpdate = await _unitOfWork.CodigoDDIRepository.ObterPorId(command.Id);
            CodigoDDIUpdate!.Update(command.Codigo);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCodigoDDICommand(
                command.Id,
                command.Codigo);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
