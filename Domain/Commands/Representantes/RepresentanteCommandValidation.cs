using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Representantes
{
    public class RepresentanteCommandValidation<T> : AbstractValidator<RepresentanteCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepresentanteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.IdPessoa)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);


            RuleFor(c => c.IdPessoa)
               .MustAsync(async (s, cancellation) => await PessoaExisteNoDB(s))
               .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> PessoaExisteNoDB(Guid? id)
        {
            var idPessoa = id ?? Guid.Empty;
            if (idPessoa == Guid.Empty)
                return false;

            return await _unitOfWork.PessoaRepository.ExisteIdAsync(idPessoa);
        }
    }
}
