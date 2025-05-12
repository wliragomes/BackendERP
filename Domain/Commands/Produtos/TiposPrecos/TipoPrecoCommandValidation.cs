using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.TiposPrecos
{
    public class TipoPrecoCommandValidation<T> : AbstractValidator<TipoPrecoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TipoPrecoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Descricao)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Descricao!, s.Id))
                .OverridePropertyName(x => x.Descricao)
                .WithState(x => x.Descricao)
                .WithMessage(TipoPrecoConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Descricao), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.TipoPrecoRepository.ExisteNomeAsync(nome, id);
    }
}
