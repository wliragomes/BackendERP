using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Cidades
{
    public class CidadeCommandValidation<T> : AbstractValidator<CidadeCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY)
                .MaximumLength(CidadeConstant.MaxLengthNome)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, CidadeConstant.MaxLengthNome));

            RuleFor(c => c)
                .MustAsync(async (command, cancellation) => await ExisteCidadeDuplicadaNoDB(command.Nome!, command.IdEstado, command.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(CidadeConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);

            RuleFor(c => c.IdEstado)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await EstadoExisteNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);

            RuleFor(c => c.CodIBGE)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY)
                .MaximumLength(CidadeConstant.MaxLengthCodIBGE)
                .WithMessage(string.Format(ConstantGeneral.CANNOT_GREATER_THAN, CidadeConstant.MaxLengthCodIBGE));
        }

        private async Task<bool> EstadoExisteNoDB(Guid? id) =>
            await _unitOfWork.EstadoRepository.ExisteIdAsync(id);

        private async Task<bool> ExisteCidadeDuplicadaNoDB(string nome, Guid? idEstado, Guid? id) =>
            !await _unitOfWork.CidadeRepository.ExisteCidadeDuplicadaAsyn(nome, idEstado, id);
    }
}
