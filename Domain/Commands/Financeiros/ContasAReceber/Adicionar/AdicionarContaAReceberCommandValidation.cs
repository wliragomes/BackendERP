using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasAReceber.Adicionar
{
    public class AdicionarContaAReceberCommandValidation : AbstractValidator<AdicionarContaAReceberCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarContaAReceberCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ContaAReceberCommandValidation<AdicionarContaAReceberCommand>(_unitOfWork));
        }
    }
}
