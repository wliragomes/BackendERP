using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Cartoes.Adicionar
{
    public class AdicionarCartaoCommandValidation : AbstractValidator<AdicionarCartaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCartaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CartaoCommandValidation<AdicionarCartaoCommand>(_unitOfWork));
        }
    }
}
