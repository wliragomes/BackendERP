using Domain.Constant;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Duplicatas
{
    public class DuplicataCommandValidation<T> : AbstractValidator<DuplicataCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DuplicataCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Numero)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
        }
    }
}
