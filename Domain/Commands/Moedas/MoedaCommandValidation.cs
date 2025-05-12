using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Moedas
{
    public class MoedaCommandValidation<T> : AbstractValidator<MoedaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoedaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);


            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(MoedaConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id)
        {
            return !await _unitOfWork.MoedaRepository.ExisteNomeAsync(nome, id);
        }
    }
}
