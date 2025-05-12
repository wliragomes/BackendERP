using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Operacoes.Adicionar
{
    public class AdicionarOperacaoCommandValidation : AbstractValidator<AdicionarOperacaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarOperacaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new OperacaoCommandValidation<AdicionarOperacaoCommand>(_unitOfWork));
        }
    }
}
