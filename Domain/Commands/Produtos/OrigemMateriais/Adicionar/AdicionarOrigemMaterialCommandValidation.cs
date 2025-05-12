using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.OrigemMateriais.Adicionar
{
    public class AdicionarOrigemMaterialCommandValidation : AbstractValidator<AdicionarOrigemMaterialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarOrigemMaterialCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new OrigemMaterialCommandValidation<AdicionarOrigemMaterialCommand>(_unitOfWork));
        }
    }
}
