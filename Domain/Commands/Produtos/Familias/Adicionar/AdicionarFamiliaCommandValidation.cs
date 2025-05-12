using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Familias.Adicionar
{
    public class AdicionarFamiliaCommandValidation : AbstractValidator<AdicionarFamiliaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFamiliaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FamiliaCommandValidation<AdicionarFamiliaCommand>(_unitOfWork));
        }
    }
}
