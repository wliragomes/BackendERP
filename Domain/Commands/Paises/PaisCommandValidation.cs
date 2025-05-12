using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Paises
{
    public class PaisCommandValidation<T> : AbstractValidator<PaisCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaisCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(PaisConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(PaisConstant.MaxLengthNome)
                .WithMessage(string.Format(PaisConstant.CARACTERES_PERMITIDO, PaisConstant.MaxLengthNome));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.PaisRepository.ExisteNomeAsync(nome, id);
    }
}
