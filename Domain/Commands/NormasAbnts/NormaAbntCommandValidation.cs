using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.NormasAbnts
{
    public class NormaAbntCommandValidation<T> : AbstractValidator<NormaAbntCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public NormaAbntCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.NNbr)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.NNbr!, s.Id))
                .OverridePropertyName(x => x.NNbr)
                .WithState(x => x.NNbr)
                .WithMessage(NormaAbntConstant.NORMA_ABNT_JA_REGISTRADA)
                .When(x => !string.IsNullOrEmpty(x.NNbr), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.NNbr)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(NormaAbntConstant.MaxLengthNnbr)
                .WithMessage(string.Format(NormaAbntConstant.CARACTERES_PERMITIDO, NormaAbntConstant.MaxLengthNnbr));

            RuleFor(c => c.Descricao)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(NormaAbntConstant.MaxLengthDescricaoNorma)
                .WithMessage(string.Format(NormaAbntConstant.CARACTERES_PERMITIDO, NormaAbntConstant.MaxLengthDescricaoNorma));

            RuleFor(c => c.Pedido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(NormaAbntConstant.MaxLengthPedido)
                .WithMessage(string.Format(NormaAbntConstant.CARACTERES_PERMITIDO, NormaAbntConstant.MaxLengthPedido));
        }

        private async Task<bool> NomeExistInDb(string nnbr, Guid? id) =>
           !await _unitOfWork.NormaAbntRepository.ExisteNomeAsync(nnbr, id);
    }
}
