using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ObraOrigems.Adicionar
{
    public class AdicionarObraOrigemCommandValidation : AbstractValidator<AdicionarObraOrigemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarObraOrigemCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ObraOrigemCommandValidation<AdicionarObraOrigemCommand>(_unitOfWork));
        }
    }
}
