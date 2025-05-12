using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.CepsBloqueados
{
    public class CepBloqueadoCommandValidation<T> : AbstractValidator<CepBloqueadoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CepBloqueadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.NumeroCep)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NumeroCepExistInDb(s.NumeroCep!, s.Id))
                .OverridePropertyName(x => x.NumeroCep)
                .WithState(x => x.NumeroCep)
                .WithMessage(CepBloqueadoConstant.CEP_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.NumeroCep), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> NumeroCepExistInDb(string numeroCep, Guid? id)
        {
            return !await _unitOfWork.CepBloqueadoRepository.ExisteNumeroCepAsync(numeroCep, id);
        }
    }
}
