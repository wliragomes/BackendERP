using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.NiveisAcessos
{
    public class NivelAcessoCommandValidation<T> : AbstractValidator<NivelAcessoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public NivelAcessoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.Nome)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c)
                .MustAsync(async (s, cancellation) => await NomeExistInDb(s.Nome!, s.Id))
                .OverridePropertyName(x => x.Nome)
                .WithState(x => x.Nome)
                .WithMessage(NivelAcessoConstant.NOME_JA_REGISTRADO)
                .When(x => !string.IsNullOrEmpty(x.Nome), ApplyConditionTo.CurrentValidator);
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.NivelAcessoRepository.ExisteNomeAsync(nome, id);
    }
}
