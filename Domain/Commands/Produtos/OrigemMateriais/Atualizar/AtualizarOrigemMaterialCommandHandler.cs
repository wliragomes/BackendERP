using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.OrigemMateriais.Atualizar
{
    public class AtualizarOrigemMaterialCommandHandler : IRequestHandler<AtualizarOrigemMaterialCommand, FormularioResponse<AtualizarOrigemMaterialCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarOrigemMaterialCommand> _validator;
        private const int _indice = 0;

        public AtualizarOrigemMaterialCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarOrigemMaterialCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarOrigemMaterialCommand>> Handle(AtualizarOrigemMaterialCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarOrigemMaterialCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var origemmaterialUpdate = await _unitOfWork.OrigemMaterialRepository.ObterPorId(command.Id);
            origemmaterialUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarOrigemMaterialCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
