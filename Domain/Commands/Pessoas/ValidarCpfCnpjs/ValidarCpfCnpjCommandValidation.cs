using Domain.Commands.Pessoas.ValidarCpfCnpjs;
using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ValidarCpfCnpjs
{
    public class ValidarCpfCnpjCommandValidation<T> : AbstractValidator<ValidarCpfCnpjCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ValidarCpfCnpjCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.CpfCnpj)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await CpfCnpjExistInDb(s.CpfCnpj!))
                .OverridePropertyName(x => x.CpfCnpj)
                .WithState(x => x.CpfCnpj)
                .WithMessage(PessoaConstant.CPFCNPJ_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.CpfCnpj), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> CpfCnpjExistInDb(string cpfCnpj) =>
           !await _unitOfWork.PessoaRepository.ExisteCpfCnpjAsync(cpfCnpj);
    }
}
