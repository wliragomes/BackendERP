using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Commands.FaturaParametros
{
    public class FaturaParametroCommandValidation<T> : AbstractValidator<FaturaParametroCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FaturaParametroCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Modelo)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.Serie)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.PrimeiroNumero)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);          


            //RuleFor(c => c)
            //    .MustAsync(async (s, cancellation) => await SerieExistInDb(s.Serie!, s.Id))
            //    .OverridePropertyName(x => x.Serie)
            //    .WithState(x => x.Serie)
            //    .WithMessage(FaturaParametroConstant.NOME_JA_REGISTRADO)
            //    .When(x => !string.IsNullOrEmpty(x.Serie), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Serie)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(FaturaParametroConstant.MaxLengthSerie)
                .WithMessage(string.Format(FaturaParametroConstant.CARACTERES_PERMITIDO, FaturaParametroConstant.MaxLengthSerie));
        }

        //private async Task<bool> SerieExistInDb(string modelo, Guid? id)
        //{
        //    return !await _unitOfWork.FaturaParametroRepository.ExisteSerieAsync(modelo, id);
        //}
    }
}
