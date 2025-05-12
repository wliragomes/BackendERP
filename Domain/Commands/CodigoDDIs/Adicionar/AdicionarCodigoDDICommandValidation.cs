using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.CodigoDDIs.Adicionar
{
    public class AdicionarCodigoDDICommandValidation : AbstractValidator<AdicionarCodigoDDICommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCodigoDDICommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CodigoDDICommandValidation<AdicionarCodigoDDICommand>(_unitOfWork));
        }
    }
}
