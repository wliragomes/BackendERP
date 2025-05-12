using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.TipoFretes
{
    public class TipoFreteCommandValidation<T> : AbstractValidator<TipoFreteCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoFreteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(DescricaoNaoExistir)
                .WithMessage(TipoFreteConstant.FRETE_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Descricao));
        }

        private async Task<bool> DescricaoNaoExistir(TipoFreteCommand<T> command, CancellationToken cancellation)
        {
            return !await _unitOfWork.TipoFreteRepository.ExisteDescricaoAsync(command.Descricao, command.Id);
        }
    }
}