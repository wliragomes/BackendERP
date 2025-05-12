using Domain.Constant;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.ClasseReajustes
{
    public class DesgastePolimentoCommandValidation<T> : AbstractValidator<DesgastePolimentoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DesgastePolimentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.EspessuraVidroMinimo)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.EspessuraVidroMaximo)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.QuantidadeDesgasteLado)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);

            RuleFor(c => c.QuantidadeDesgasteTotal)
                .NotNull()
                .WithMessage(ErrorMessages.CANNOT_BE_EMPTY);
        }

        private async Task<bool> NomeExistInDb(string nome, Guid? id) =>
           !await _unitOfWork.GrupoRepository.ExisteNomeAsync(nome, id);
    }
}
