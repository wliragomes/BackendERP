using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.PlanosDeContas
{
    public class PlanoDeContasCommandValidation<T> : AbstractValidator<PlanoDeContasCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlanoDeContasCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.PlanoDeContasCompleto)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await PlanoDeContaExisteInDb(s.PlanoDeContasCompleto!, s.Id))
                .OverridePropertyName(x => x.PlanoDeContasCompleto)
                .WithState(x => x.PlanoDeContasCompleto)
                .WithMessage(PlanoDeContaConstant.PLANO_CONTAS_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.PlanoDeContasCompleto), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> PlanoDeContaExisteInDb(string planoDeContasCompleto, Guid? id)
        {
            return !await _unitOfWork.PlanoDeContasRepository.ExistePlanoDeContaAsync(planoDeContasCompleto, id);
        }
    }
}
