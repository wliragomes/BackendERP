using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Cfops.Adicionar
{
    public class AdicionarCfopCommandValidation : AbstractValidator<AdicionarCfopCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCfopCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CfopCommandValidation<AdicionarCfopCommand>(_unitOfWork));
        }
    }
}
