using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Empresas
{
    public class EmpresaCommandValidation<T> : AbstractValidator<EmpresaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmpresaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(c => c.CpfCnpj)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.RazaoSocial)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.NomeFantasia)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdRegimeTributario)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await CpfCnpjExistInDb(s.CpfCnpj!, s.Id))
                .OverridePropertyName(x => x.CpfCnpj)
                .WithState(x => x.CpfCnpj)
                .WithMessage(EmpresaConstant.CPFCNPJ_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.CpfCnpj), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.CpfCnpj)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EmpresaConstant.MaxLengthCpfCnpj)
                .WithMessage(string.Format(EmpresaConstant.CARACTERES_PERMITIDO_18, EmpresaConstant.MaxLengthCpfCnpj));

            RuleFor(c => c.InscricaoEstadual)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EmpresaConstant.MaxLengthInscricaoEstadual)
                .WithMessage(string.Format(EmpresaConstant.CARACTERES_PERMITIDO_50, EmpresaConstant.MaxLengthInscricaoEstadual));

            RuleFor(c => c.InscricaoSuframa)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EmpresaConstant.MaxLengthInscricaoSuframa)
                .WithMessage(string.Format(EmpresaConstant.CARACTERES_PERMITIDO_50, EmpresaConstant.MaxLengthInscricaoSuframa));

            RuleFor(c => c.RazaoSocial)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EmpresaConstant.MaxLengthRazaoSocial)
                .WithMessage(string.Format(EmpresaConstant.CARACTERES_PERMITIDO_255, EmpresaConstant.MaxLengthRazaoSocial));

            RuleFor(c => c.NomeFantasia)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EmpresaConstant.MaxLengthNomeFantasia)
                .WithMessage(string.Format(EmpresaConstant.CARACTERES_PERMITIDO_255, EmpresaConstant.MaxLengthNomeFantasia));            
        }

        private async Task<bool> CpfCnpjExistInDb(string cpfcnpj, Guid? id)
        {
            return !await _unitOfWork.EmpresaRepository.ExisteCpfCnpjAsync(cpfcnpj, id);
        }
    }
}
