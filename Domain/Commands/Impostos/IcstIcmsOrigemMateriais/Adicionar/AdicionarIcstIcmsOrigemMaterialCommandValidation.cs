using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Impostos.IcstIcmsOrigemMateriais.Adicionar
{
    public class AdicionarIcstIcmsOrigemMaterialCommandValidation : AbstractValidator<AdicionarIcstIcmsOrigemMaterialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarIcstIcmsOrigemMaterialCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new IcstIcmsOrigemMaterialCommandValidation<AdicionarIcstIcmsOrigemMaterialCommand>(_unitOfWork));
        }
    }
}
