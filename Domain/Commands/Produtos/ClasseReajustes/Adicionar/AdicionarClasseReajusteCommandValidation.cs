using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.ClasseReajustes.Adicionar
{
    public class AdicionarClasseReajusteCommandValidation : AbstractValidator<AdicionarClasseReajusteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarClasseReajusteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ClasseReajusteCommandValidation<AdicionarClasseReajusteCommand>(_unitOfWork));
        }
    }
}
