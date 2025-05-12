using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.Ncms
{
    public class NcmCommandValidation<T> : AbstractValidator<NcmCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public NcmCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Descricao!, s.Id))
                .OverridePropertyName(x => x.Descricao)
                .WithState(x => x.Descricao)
                .WithMessage(NcmConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Descricao), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.NrNcm01)
                .MaximumLength(NcmConstant.MaxLengthNrNcm01)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, NcmConstant.MaxLengthNrNcm01));

            RuleFor(c => c.NrNcm02)
                .MaximumLength(NcmConstant.MaxLengthNrNcm02)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, NcmConstant.MaxLengthNrNcm02));

            RuleFor(c => c.NrNcm03)
                .MaximumLength(NcmConstant.MaxLengthNrNcm03)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, NcmConstant.MaxLengthNrNcm03));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.NcmRepository.ExisteNomeAsync(nome, id);
    }
}
