using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Familias.Atualizar
{
    public class AtualizarFamiliaCommandHandler : IRequestHandler<AtualizarFamiliaCommand, FormularioResponse<AtualizarFamiliaCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarFamiliaCommand> _validator;
        private const int _indice = 0;

        public AtualizarFamiliaCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarFamiliaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarFamiliaCommand>> Handle(AtualizarFamiliaCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarFamiliaCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var FamiliaUpdate = await _unitOfWork.FamiliaRepository.ObterPorId(command.Id);
            FamiliaUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarFamiliaCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
