using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposProdutos.Adicionar
{
    public class AdicionarTipoProdutoCommandHandler : IRequestHandler<AdicionarTipoProdutoCommand, FormularioResponse<AdicionarTipoProdutoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarTipoProdutoCommand> _validator;
        private const int _indece = 0;

        public AdicionarTipoProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarTipoProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarTipoProdutoCommand>> Handle(AdicionarTipoProdutoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarTipoProdutoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            TipoProduto tipoproduto = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.TipoProdutoRepository.Adicionar(tipoproduto);
                response.Formulario!.SetId(tipoproduto.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
