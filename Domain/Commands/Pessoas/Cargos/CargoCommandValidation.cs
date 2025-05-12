using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Cargos
{
    public class CargoCommandValidation<T> : AbstractValidator<CargoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CargoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await DescricaoExistInDb(s.Descricao!, s.Id))
                .OverridePropertyName(x => x.Descricao)
                .WithState(x => x.Descricao)
                .WithMessage(CargoConstant.DESCRICAO_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Descricao), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> DescricaoExistInDb(string descricao, Guid? id) =>
           !await _unitOfWork.CargoRepository.ExisteDescricaoAsync(descricao, id);
    }
}
