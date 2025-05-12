using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposProdutos.Atualizar
{
    public class AtualizarTipoProdutoCommandHandler : IRequestHandler<AtualizarTipoProdutoCommand, FormularioResponse<AtualizarTipoProdutoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarTipoProdutoCommand> _validator;
        private const int _indice = 0;

        public AtualizarTipoProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarTipoProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarTipoProdutoCommand>> Handle(AtualizarTipoProdutoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarTipoProdutoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var tipoprodutoUpdate = await _unitOfWork.TipoProdutoRepository.ObterPorId(command.Id);
            tipoprodutoUpdate!.Update(command.Descricao);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarTipoProdutoCommand(
                command.Id,
                command.Descricao);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}
