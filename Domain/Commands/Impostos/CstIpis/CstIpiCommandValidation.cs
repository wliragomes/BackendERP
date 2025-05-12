using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.CstIpis
{
    public class CstIpiCommandValidation<T> : AbstractValidator<CstIpiCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CstIpiCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(CST_IPIConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.CstIpiAmigavel)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CST_IPIConstant.MaxLengthCstIpiAmigavel)
                .WithMessage(string.Format(CST_IPIConstant.CARACTERES_PERMITIDO, CST_IPIConstant.MaxLengthCstIpiAmigavel));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.CST_IPIRepository.ExisteNomeAsync(nome, id);
    }
}

