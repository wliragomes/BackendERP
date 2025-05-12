using Domain.Commands.Common;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Auth.UpdatePassword
{
    public class UpdatePasswordValidation : AbstractValidator<UpdateLoginPasswordCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private SharedMethods _sharedMethods;

        public UpdatePasswordValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _sharedMethods = new SharedMethods(_unitOfWork);

            RuleFor(c => c.IdUser)
            .NotEmpty()
            .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            .OverridePropertyName(x => x.IdUser);

            When(x => !string.IsNullOrWhiteSpace(x.IdUser.ToString()), () =>
            {
                RuleFor(c => c.IdUser)
                .MustAsync(async (x, cancellation) => await _sharedMethods.ItemExistInDb(x, _unitOfWork))
                .WithMessage(ConstantGeneral.NOT_FOUND);
            });

            RuleFor(c => c.NewPassword)
            .NotEmpty()
            .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            .OverridePropertyName(x => x.NewPassword);

            RuleFor(c => c.NewPasswordConfirmation)
            .NotEmpty()
            .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            .OverridePropertyName(x => x.NewPasswordConfirmation);
            _unitOfWork = unitOfWork;

            When(x => !string.IsNullOrWhiteSpace(x.NewPassword) && !string.IsNullOrWhiteSpace(x.NewPasswordConfirmation), () =>
            {
                RuleFor(c => c.NewPassword)
                .Equal(c => c.NewPasswordConfirmation)
                .WithMessage(UserConstant.PASSWORD_NOT_EQUAL_CONFIRMATION)
                .OverridePropertyName(x => x.NewPassword);
            });
        }
    }
}
