using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Chapas
{
    public class ChapaCommandValidation<T> : AbstractValidator<ChapaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChapaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);


            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await DescricaoExistInDb(s.Descricao!, s.Id))
                .OverridePropertyName(x => x.Descricao)
                .WithState(x => x.Descricao)
                .WithMessage(ChapaConstant.DESCRICAO_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Descricao), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> DescricaoExistInDb(string descricao, Guid? id)
        {
            return !await _unitOfWork.ChapaRepository.ExisteDescricaoAsync(descricao, id);
        }
    }
}
