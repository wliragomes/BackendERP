using Domain.Constant;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasAPagar
{
    public class ContaAPagarCommandValidation<T> : AbstractValidator<ContaAPagarCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContaAPagarCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.NDocumento)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
        }
    }
}
