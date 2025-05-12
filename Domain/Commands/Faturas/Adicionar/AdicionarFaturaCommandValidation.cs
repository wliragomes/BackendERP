using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Faturas.Adicionar
{
    public class AdicionarFaturaCommandValidation : AbstractValidator<AdicionarFaturaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFaturaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
                .SetValidator(new FaturaCommandValidation<AdicionarFaturaCommand>(_unitOfWork));
        }
    }
}
