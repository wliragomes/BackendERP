using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.SetoresProdutos.Atualizar
{
    public class AtualizarSetorProdutoCommandHandler : IRequestHandler<AtualizarSetorProdutoCommand, FormularioResponse<AtualizarSetorProdutoCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<AtualizarSetorProdutoCommand> _validator;
        private const int _indice = 0;

        public AtualizarSetorProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<AtualizarSetorProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AtualizarSetorProdutoCommand>> Handle(AtualizarSetorProdutoCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AtualizarSetorProdutoCommand>(_indice, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            var setorprodutoUpdate = await _unitOfWork.SetorProdutoRepository.ObterPorId(command.Id);
            setorprodutoUpdate!.Update(
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
                command.MostrarCadastro);

            await _unitOfWork.CommitAsync(cancellationToken);

            var commandAtualizado = new AtualizarSetorProdutoCommand(
                command.Id, 
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
                command.MostrarCadastro);

            response.SetFormulario(commandAtualizado);
            return response;
        }
    }
}