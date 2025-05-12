using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.CstIcmss.Adicionar
{
    public class AdicionarCstIcmsCommandValidation : AbstractValidator<AdicionarCstIcmsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCstIcmsCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CstIcmsCommandValidation<AdicionarCstIcmsCommand>(_unitOfWork));
        }
    }
}
