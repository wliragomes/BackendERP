using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Estados.Adicionar
{
    public class AdicionarEstadoCommandValidation : AbstractValidator<AdicionarEstadoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarEstadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new EstadoCommandValidation<AdicionarEstadoCommand>(_unitOfWork));
        }
    }
}