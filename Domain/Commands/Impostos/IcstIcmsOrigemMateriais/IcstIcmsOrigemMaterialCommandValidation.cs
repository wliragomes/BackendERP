using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais
{
    public class IcstIcmsOrigemMaterialCommandValidation<T> : AbstractValidator<IcstIcmsOrigemMaterialCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public IcstIcmsOrigemMaterialCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(CstIcmsOrigemMaterialConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.CST_ICMS_Amigavel_Origem_Material)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CstIcmsOrigemMaterialConstant.MaxLengthCstOrigemMaterialAmigavel)
                .WithMessage(string.Format(CstIcmsOrigemMaterialConstant.CARACTERES_PERMITIDO, CstIcmsOrigemMaterialConstant.MaxLengthCstOrigemMaterialAmigavel));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.CST_ICMS_Origem_MaterialRepository.ExisteNomeAsync(nome, id);
    }
}
