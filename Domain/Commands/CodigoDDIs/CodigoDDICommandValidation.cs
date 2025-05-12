using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.CodigoDDIs
{
    public class CodigoDDICommandValidation<T> : AbstractValidator<CodigoDDICommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CodigoDDICommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Codigo)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await CodigoExistInDb(s.Codigo!, s.Id))
                .OverridePropertyName(x => x.Codigo)
                .WithState(x => x.Codigo)
                .WithMessage(CodigoDDIConstant.CODIGO_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Codigo), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> CodigoExistInDb(string nome, Guid? id)
        {
            return !await _unitOfWork.CodigoDDIRepository.ExisteCodigoAsync(nome, id);
        }
    }
}
