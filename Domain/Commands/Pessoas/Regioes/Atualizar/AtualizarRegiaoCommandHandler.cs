using Domain.Commands.Regioes.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.regioes.Atualizar
{
    public class AtualizarRegiaoCommandHandler : IRequestHandler<AtualizarRegiaoCommand, FormularioResponse<AtualizarRegiaoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarRegiaoCommand> _validator;
        private const int _indice = 0;

        public AtualizarRegiaoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarRegiaoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarRegiaoCommand>> Handle(AtualizarRegiaoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarRegiaoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var RegiaoUpdate = await _unitOfWork.RegiaoRepository.ObterPorId(command.Id);
            RegiaoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarRegiaoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
