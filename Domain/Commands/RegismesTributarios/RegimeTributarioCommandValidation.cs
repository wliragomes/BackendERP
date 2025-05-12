using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.RegimeTributarios
{
    public class RegimeTributarioCommandValidation<T> : AbstractValidator<RegimeTributarioCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegimeTributarioCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);   

            RuleFor(c => c.ValorPis)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);   

            RuleFor(c => c.ValorCofins)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);     

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(RegimeTributarioConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(RegimeTributarioConstant.MaxLengthNome)
                .WithMessage(string.Format(RegimeTributarioConstant.CARACTERES_PERMITIDO_255, RegimeTributarioConstant.MaxLengthNome));

        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id)
        {
            return !await _unitOfWork.RegimeTributarioRepository.ExisteNomeAsync(nome, id);
        }
    }
}
