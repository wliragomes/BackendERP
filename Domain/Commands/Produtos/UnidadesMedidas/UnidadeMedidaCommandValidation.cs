using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Produtos.UnidadesMedidas
{
    public class UnidadeMedidaCommandValidation<T> : AbstractValidator<UnidadeMedidaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnidadeMedidaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Descricao!, s.Id))
                .OverridePropertyName(x => x.Descricao)
                .WithState(x => x.Descricao)
                .WithMessage(UnidadeMedidaConstant.UNIDADE_JA_REGISTRADA)
                .When(x => !string.IsNullOrEmpty(x.Descricao), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Sigla)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY)
                .MaximumLength(UnidadeMedidaConstant.MaxLengthSigla)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, UnidadeMedidaConstant.MaxLengthSigla));

            RuleFor(c => c.CasaDecimal)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
                //.MaximumLength(UnidadeMedidaConstant.MaxLengthCasaDecimal)
                //.WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, UnidadeMedidaConstant.MaxLengthCasaDecimal));
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.UnidadeMedidaRepository.ExisteNomeAsync(nome, id);
    }
}
