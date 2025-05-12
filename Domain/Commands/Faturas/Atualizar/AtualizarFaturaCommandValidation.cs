using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Faturas.Atualizar
{
    public class AtualizarFaturaCommandValidation : AbstractValidator<AtualizarFaturaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarFaturaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FaturaCommandValidation<AtualizarFaturaCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD);            
        }
    }
}
