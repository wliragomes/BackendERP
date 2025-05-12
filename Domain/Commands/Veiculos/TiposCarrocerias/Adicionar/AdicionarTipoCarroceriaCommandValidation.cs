using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.TiposCarrocerias.Adicionar
{
    public class AdicionarTipoCarroceriaCommandValidation : AbstractValidator<AdicionarTipoCarroceriaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarTipoCarroceriaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new TipoCarroceriaCommandValidation<AdicionarTipoCarroceriaCommand>(_unitOfWork));
        }
    }
}
