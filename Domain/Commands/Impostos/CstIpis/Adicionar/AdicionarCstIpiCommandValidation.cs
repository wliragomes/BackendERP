using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.CstIpis.Adicionar
{
    public class AdicionarCstIpiCommandValidation : AbstractValidator<AdicionarCstIpiCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCstIpiCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CstIpiCommandValidation<AdicionarCstIpiCommand>(_unitOfWork));
        }
    }
}
