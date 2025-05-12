using Domain.Entities.Produtos;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.SetoresProdutos.Adicionar
{
    public class AdicionarSetorProdutoCommandHandler : IRequestHandler<AdicionarSetorProdutoCommand, FormularioResponse<AdicionarSetorProdutoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarSetorProdutoCommand> _validator;
        private const int _indece = 0;

        public AdicionarSetorProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarSetorProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarSetorProdutoCommand>> Handle(AdicionarSetorProdutoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarSetorProdutoCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            SetorProduto setorproduto = new
            (
                command.CodigoSetor, 
                command.Componente, 
                command.Cmax, 
                command.Cmin, 
                command.Lmax, 
                command.Lmin, 
                command.Descricao, 
                command.Perfil,
                command.CobrancaMinima,
                command.SetorFabricacao,
                command.Pvb,
                command.Argonio,
                command.MostrarCadastro

            );

            await _unitOfWork.SetorProdutoRepository.Adicionar(setorproduto);
            response.Formulario!.SetId(setorproduto.Id);

            await _unitOfWork.CommitAsync(cancellationToken);
            return response;
         }
    }
}