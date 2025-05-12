using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Cfops
{
    public class CfopCommandValidation<T> : AbstractValidator<CfopCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CfopCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(c => c.CodigoAmigavel)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);            

            RuleFor(c => c.DsResumida)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.DsDetalhada)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.EntradaSaida)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.DadosAdicionaisIcms)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.DadosAdicionaisIpi)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdCstIcms)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdCstIcmsOrigemMaterial)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdCstIpi)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdCstPis)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdCstCofins)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.CodigoAmigavel)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CfopConstant.MaxLengthCodigoAmigavel)
                .WithMessage(string.Format(CfopConstant.CARACTERES_PERMITIDO_5, CfopConstant.MaxLengthCodigoAmigavel));

            RuleFor(c => c.DsResumida)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CfopConstant.MaxLengthDsResumida)
                .WithMessage(string.Format(CfopConstant.CARACTERES_PERMITIDO_60, CfopConstant.MaxLengthDsResumida));

            RuleFor(c => c.DsDetalhada)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CfopConstant.MaxLengthDsDetalhada)
                .WithMessage(string.Format(CfopConstant.CARACTERES_PERMITIDO_500, CfopConstant.MaxLengthDsDetalhada));

            RuleFor(c => c.EntradaSaida)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CfopConstant.MaxLengthEntradaSaida)
                .WithMessage(string.Format(CfopConstant.CARACTERES_PERMITIDO_1, CfopConstant.MaxLengthEntradaSaida));

            RuleFor(c => c.DadosAdicionaisIcms)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CfopConstant.MaxLengthDadosAdicionaisIcms)
                .WithMessage(string.Format(CfopConstant.CARACTERES_PERMITIDO_500, CfopConstant.MaxLengthDadosAdicionaisIcms));

            RuleFor(c => c.DadosAdicionaisIpi)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(CfopConstant.MaxLengthDadosAdicionaisIpi)
                .WithMessage(string.Format(CfopConstant.CARACTERES_PERMITIDO_500, CfopConstant.MaxLengthDadosAdicionaisIpi));
        }

        private async Task<bool> CodigoExistInDb(string codigo, Guid? id)
        {
            return !await _unitOfWork.CfopRepository.ExisteCodigoAsync(codigo, id);
        }
    }
}
