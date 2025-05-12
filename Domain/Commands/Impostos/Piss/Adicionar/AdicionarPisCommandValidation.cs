using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.Piss.Adicionar
{
    public class AdicionarPisCommandValidation : AbstractValidator<AdicionarPisCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarPisCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
                .SetValidator(new PisCommandValidation<AdicionarPisCommand>(_unitOfWork));
        }
    }
}
