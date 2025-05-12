using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Modalidades
{
    public class ModalidadeCommandValidation<T> : AbstractValidator<ModalidadeCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModalidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.DescricaoModalidade)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.DescricaoModalidade)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(ModalidadeConstant.MaxLengthDescricaoModalidade)
                .WithMessage(string.Format(ModalidadeConstant.CARACTERES_PERMITIDO, ModalidadeConstant.MaxLengthDescricaoModalidade));
        }
    }
}
