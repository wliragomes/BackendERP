using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Regioes.Adicionar
{
    public class AdicionarRegiaoCommandValidation : AbstractValidator<AdicionarRegiaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarRegiaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new RegiaoCommandValidation<AdicionarRegiaoCommand>(_unitOfWork));
        }
    }
}
