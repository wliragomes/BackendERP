using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Setores.Atualizar
{
    public class AtualizarSetorCommandHandler : IRequestHandler<AtualizarSetorCommand, FormularioResponse<AtualizarSetorCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarSetorCommand> _validator;
        private const int _indice = 0;

        public AtualizarSetorCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarSetorCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarSetorCommand>> Handle(AtualizarSetorCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarSetorCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var SetorUpdate = await _unitOfWork.SetorRepository.ObterPorId(command.Id);
            SetorUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarSetorCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}