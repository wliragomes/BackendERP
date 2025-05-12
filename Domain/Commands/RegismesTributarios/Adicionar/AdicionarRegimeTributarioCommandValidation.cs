using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.RegimeTributarios.Adicionar
{
    public class AdicionarRegimeTributarioCommandValidation : AbstractValidator<AdicionarRegimeTributarioCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarRegimeTributarioCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new RegimeTributarioCommandValidation<AdicionarRegimeTributarioCommand>(_unitOfWork));
        }
    }
}
