using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.ContasBancarias
{
    public class ContaBancariaCommandValidation<T> : AbstractValidator<ContaBancariaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContaBancariaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Agencia)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.DigitoAgencia)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.Conta)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
            

            RuleFor(c => c.DigitoConta)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.IdBanco)
               .MustAsync(async (s, cancellation) => await BancoExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> BancoExisteNoDB(Guid? id)
        {
            var idBanco = id ?? Guid.Empty;
            if (idBanco == Guid.Empty)
                return false;

            return await _unitOfWork.BancoRepository.ExisteIdAsync(idBanco);
        }
    }
}
