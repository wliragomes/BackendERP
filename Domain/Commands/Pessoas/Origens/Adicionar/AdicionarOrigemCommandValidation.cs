using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Origens.Adicionar
{
    public class AdicionarOrigemCommandValidation : AbstractValidator<AdicionarOrigemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarOrigemCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new OrigemCommandValidation<AdicionarOrigemCommand>(_unitOfWork));
        }
    }
}
