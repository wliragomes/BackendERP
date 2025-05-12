using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Moedas.Adicionar
{
    public class AdicionarMoedaCommandValidation : AbstractValidator<AdicionarMoedaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarMoedaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new MoedaCommandValidation<AdicionarMoedaCommand>(_unitOfWork));
        }
    }
}
