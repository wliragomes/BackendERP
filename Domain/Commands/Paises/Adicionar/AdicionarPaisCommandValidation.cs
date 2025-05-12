using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Paises.Adicionar
{
    public class AdicionarPaisCommandValidation : AbstractValidator<AdicionarPaisCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarPaisCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new PaisCommandValidation<AdicionarPaisCommand>(_unitOfWork));
        }
    }
}