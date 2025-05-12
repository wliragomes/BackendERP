using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ObraFases.Adicionar
{
    public class AdicionarObraFaseCommandValidation : AbstractValidator<AdicionarObraFaseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarObraFaseCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ObraFaseCommandValidation<AdicionarObraFaseCommand>(_unitOfWork));
        }
    }
}
