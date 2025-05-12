using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.CstIcmss
{
    public class CstIcmsCommandValidation<T> : AbstractValidator<CstIcmsCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CstIcmsCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(CST_ICMSConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.CstIcmsAmigavel)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CST_ICMSConstant.MaxLengthCstIcmsAmigavel)
                .WithMessage(string.Format(CST_ICMSConstant.CARACTERES_PERMITIDO, CST_ICMSConstant.MaxLengthCstIcmsAmigavel));            
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.CST_ICMSRepository.ExisteNomeAsync(nome, id);
    }
}
