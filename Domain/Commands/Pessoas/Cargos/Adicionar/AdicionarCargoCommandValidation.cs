using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Cargos.Adicionar
{
    public class AdicionarCargoCommandValidation : AbstractValidator<AdicionarCargoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCargoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CargoCommandValidation<AdicionarCargoCommand>(_unitOfWork));
        }
    }
}
