using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Impostos.Cofinss.Atualizar
{
    public class AtualizarCofinsCommandHandler : IRequestHandler<AtualizarCofinsCommand, FormularioResponse<AtualizarCofinsCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarCofinsCommand> _validator;
        private const int _indice = 0;

        public AtualizarCofinsCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarCofinsCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarCofinsCommand>> Handle(AtualizarCofinsCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarCofinsCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var CofinsUpdate = await _unitOfWork.CofinsRepository.ObterCofinsPorId(command.Id);
            CofinsUpdate!.Update(command.Nome, command.CofinsAmigavel, command.DescontaCofins);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarCofinsCommand(
                command.Id,
                command.Nome,
                command.CofinsAmigavel,
                command.DescontaCofins);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
