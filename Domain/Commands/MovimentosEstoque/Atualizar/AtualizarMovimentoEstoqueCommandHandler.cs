using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MovimentosEstoque.Atualizar
{
    public class AtualizarMovimentoEstoqueCommandHandler : IRequestHandler<AtualizarMovimentoEstoqueCommand, FormularioResponse<AtualizarMovimentoEstoqueCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarMovimentoEstoqueCommand> _validator;
        private const int _indice = 0;

        public AtualizarMovimentoEstoqueCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarMovimentoEstoqueCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarMovimentoEstoqueCommand>> Handle(AtualizarMovimentoEstoqueCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarMovimentoEstoqueCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var MovimentoEstoqueUpdate = await _unitOfWork.MovimentoEstoqueRepository.ObterPorId(command.Id);
            MovimentoEstoqueUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarMovimentoEstoqueCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
