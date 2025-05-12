using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.UnidadesMedidas.Adicionar
{
    public class AdicionarUnidadeMedidaCommandValidation : AbstractValidator<AdicionarUnidadeMedidaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarUnidadeMedidaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new UnidadeMedidaCommandValidation<AdicionarUnidadeMedidaCommand>(_unitOfWork));
        }
    }
}
