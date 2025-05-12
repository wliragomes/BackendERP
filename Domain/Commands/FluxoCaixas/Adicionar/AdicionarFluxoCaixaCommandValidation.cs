using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FluxoCaixas.Adicionar
{
    public class AdicionarFluxoCaixaCommandValidation : AbstractValidator<AdicionarFluxoCaixaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFluxoCaixaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FluxoCaixaCommandValidation<AdicionarFluxoCaixaCommand>(_unitOfWork));
        }
    }
}
