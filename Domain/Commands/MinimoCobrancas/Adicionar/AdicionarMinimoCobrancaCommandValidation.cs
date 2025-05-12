using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.MinimoCobrancas.Adicionar
{
    public class AdicionarMinimoCobrancaCommandValidation : AbstractValidator<AdicionarMinimoCobrancaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarMinimoCobrancaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new MinimoCobrancaCommandValidation<AdicionarMinimoCobrancaCommand>(_unitOfWork));
        }
    }
}
