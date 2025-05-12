using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.Piss
{
    public class PisCommandValidation<T> : AbstractValidator<PisCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PisCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(PisConstant.PIS_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.PisAmigavel)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ErrorMessages.REQUIRED_FIELD)
               .MaximumLength(PisConstant.MaxLengthPisAmigavel)
               .WithMessage(string.Format(PisConstant.CARACTERES_PERMITIDO, PisConstant.MaxLengthPisAmigavel));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.PisRepository.ExisteNomeAsync(nome, id);
    }
}
