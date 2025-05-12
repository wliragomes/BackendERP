using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Faturas
{
    public class FaturaCommandValidation<T> : AbstractValidator<FaturaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FaturaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.IdCliente)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage(ConstantGeneral.REQUIRED_FIELD)
               .MustAsync(async (s, cancellation) => await PessoaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> PessoaExisteNoDB(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return false;

            return await _unitOfWork.PessoaRepository.ExisteIdAsync(id);
        }
    }
}
