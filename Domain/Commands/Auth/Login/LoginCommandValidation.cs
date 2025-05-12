using Domain.Constant;
using Domain.Constants;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Auth.Login
{
    public class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(c => c.UserName)
            .NotEmpty()
            .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            .OverridePropertyName(x => x.UserName);

            RuleFor(x => x.UserName)
           .MaximumLength(LoginConstant.MaxLengthUser)
           .WithMessage(string.Format(ErrorMessages.ERROR_CANNOT_GREATER_THAN, LoginConstant.MaxLengthUser))
           .OverridePropertyName(x => x.UserName);

            RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage(ConstantGeneral.REQUIRED_FIELD)
            .OverridePropertyName(x => x.Password);
        }
    }
}
