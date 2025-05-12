using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Parametros
{
    public class ParametroCommandValidation<T> : AbstractValidator<ParametroCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParametroCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(ParametroConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Descricao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(ParametroConstant.MaxLengthDescricao)
                .WithMessage(string.Format(ParametroConstant.CARACTERES_PERMITIDO, ParametroConstant.MaxLengthDescricao));

            RuleFor(c => c.Descricao2)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(ParametroConstant.MaxLengthDescricao)
                .WithMessage(string.Format(ParametroConstant.CARACTERES_PERMITIDO, ParametroConstant.MaxLengthDescricao));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id)
        {
            return !await _unitOfWork.ParametroRepository.ExisteNomeAsync(nome, id);
        }
    }
}
