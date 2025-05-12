using Domain.Entities;
using Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.MovimentosEstoque.Adicionar
{
    public class AdicionarMovimentoEstoqueCommandHandler : IRequestHandler<AdicionarMovimentoEstoqueCommand, FormularioResponse<AdicionarMovimentoEstoqueCommand>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IValidator<AdicionarMovimentoEstoqueCommand> _validator;
        private const int _indece = 0;

        public AdicionarMovimentoEstoqueCommandHandler(IUnitOfWork unitOfWork, IValidator<AdicionarMovimentoEstoqueCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<FormularioResponse<AdicionarMovimentoEstoqueCommand>> Handle(AdicionarMovimentoEstoqueCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            var response = new FormularioResponse<AdicionarMovimentoEstoqueCommand>(_indece, command, validationResult);

            if (!validationResult.IsValid || response.ExisteErro())
                return response;

            MovimentoEstoque movimentoEstoque = new
            (
                command.Descricao
            );
            {

                await _unitOfWork.MovimentoEstoqueRepository.Adicionar(movimentoEstoque);
                response.Formulario!.SetId(movimentoEstoque.Id);

                await _unitOfWork.CommitAsync(cancellationToken);
                return response;
            }
        }
    }
}
