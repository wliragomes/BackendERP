using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Estados
{
    public class EstadoCommandValidation<T> : AbstractValidator<EstadoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EstadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EstadoConstant.MaxLengthNome)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, EstadoConstant.MaxLengthNome));

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ExisteEstadoDuplicadoNoDB(command.Nome!, command.IdPais, command.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(EstadoConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ExisteSiglaDuplicadoNoDB(command.Sigla!, command.IdPais, command.Id))
                .OverridePropertyName(x => x.Sigla)
                .WithState(x => x.Sigla)
                .WithMessage(EstadoConstant.SIGLA_JA_REGISTRADA)
                .When(x => !string.IsNullOrEmpty(x.Sigla), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.Sigla)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.REQUIRED_FIELD)
                .MaximumLength(EstadoConstant.MaxLengthSigla)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, EstadoConstant.MaxLengthSigla));

            RuleFor(c => c.IdPais)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ConstantGeneral.REQUIRED_FIELD)
               .MustAsync(async (s, cancellation) => await PaisExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.CodIBGE)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ErrorMessages.CANNOT_BE_EMPTY)
               .MaximumLength(EstadoConstant.MaxLengthCodIBGE)
               .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, EstadoConstant.MaxLengthCodIBGE));
        }

        private async Task<bool> PaisExisteNoDB(Guid? id) =>
            await _unitOfWork.PaisRepository.ExisteIdAsync(id);

        private async Task<bool> ExisteEstadoDuplicadoNoDB(string nome, Guid? idPais, Guid? id) =>
           !await _unitOfWork.EstadoRepository.ExisteEstadoDuplicadoAsyn(nome, idPais, id);

        private async Task<bool> ExisteSiglaDuplicadoNoDB(string sigla, Guid? idPais, Guid? id) =>
           !await _unitOfWork.EstadoRepository.ExisteSiglaDuplicadoAsyn(sigla, idPais, id);
    }
}
