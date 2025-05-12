using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.Cofinss
{
    public class CofinsCommandValidation<T> : AbstractValidator<CofinsCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CofinsCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await CodigoExistInDb(s.CofinsAmigavel!, s.Id))
                .OverridePropertyName(x => x.CofinsAmigavel)
                .WithState(x => x.CofinsAmigavel)
                .WithMessage(CofinsConstant.CODIGO_COFINS_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.CofinsAmigavel), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.CofinsAmigavel)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CofinsConstant.MaxLengthCofinsAmigavel)
                .WithMessage(string.Format(CofinsConstant.CARACTERES_PERMITIDO, CofinsConstant.MaxLengthCofinsAmigavel));
        }

        private async Task<bool> CodigoExistInDb(string codigo, Guid? id) =>
           !await _unitOfWork.CofinsRepository.ExisteCodigoAsync(codigo, id);
    }
}