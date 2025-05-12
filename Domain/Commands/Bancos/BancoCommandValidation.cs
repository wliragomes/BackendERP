using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Bancos
{
    public class BancoCommandValidation<T> : AbstractValidator<BancoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BancoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
            
            RuleFor(c => c.NumeroBanco)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            
            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(BancoConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            
            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NumeroExistInDb(s.NumeroBanco!, s.Id))
                .OverridePropertyName(x => x.NumeroBanco)
                .WithState(x => x.NumeroBanco)
                .WithMessage(BancoConstant.NUMERO_BANCO_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.NumeroBanco), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id)
        {
            return !await _unitOfWork.BancoRepository.ExisteNomeAsync(nome, id);
        }

        private async Task<bool> NumeroExistInDb(string numeroBanco, Guid? id)
        {
            return !await _unitOfWork.BancoRepository.ExisteNumeroBancoAsync(numeroBanco, id);
        }
    }
}
