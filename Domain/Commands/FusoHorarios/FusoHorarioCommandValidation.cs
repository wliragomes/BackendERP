using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FusoHorarios
{
    public class FusoHorarioCommandValidation<T> : AbstractValidator<FusoHorarioCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FusoHorarioCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.NumeroFusoHorario)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NumeroExistInDb(s.NumeroFusoHorario!, s.Id))
                .OverridePropertyName(x => x.NumeroFusoHorario)
                .WithState(x => x.NumeroFusoHorario)
                .WithMessage(FusoHorarioConstant.NUMERO_FUSO_HORARIO_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.NumeroFusoHorario), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> NumeroExistInDb(string numeroFusoHorario, Guid? id)
        {
            return !await _unitOfWork.FusoHorarioRepository.ExisteNumeroFusoHorarioAsync(numeroFusoHorario, id);
        }
    }
}
