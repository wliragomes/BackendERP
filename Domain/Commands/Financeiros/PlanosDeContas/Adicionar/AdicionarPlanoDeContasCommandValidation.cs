using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.PlanosDeContas.Adicionar
{
    public class AdicionarPlanoDeContasCommandValidation : AbstractValidator<AdicionarPlanoDeContasCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarPlanoDeContasCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new PlanoDeContasCommandValidation<AdicionarPlanoDeContasCommand>(_unitOfWork));
        }
    }
}
