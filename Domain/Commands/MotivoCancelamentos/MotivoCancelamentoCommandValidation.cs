using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.MotivoCancelamentos
{
    public class MotivoCancelamentoCommandValidation<T> : AbstractValidator<MotivoCancelamentoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public MotivoCancelamentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
        }
    }
}
