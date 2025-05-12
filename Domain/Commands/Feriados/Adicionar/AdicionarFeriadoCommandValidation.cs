using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Feriados.Adicionar
{
    public class AdicionarFeriadoCommandValidation : AbstractValidator<AdicionarFeriadoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFeriadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FeriadoCommandValidation<AdicionarFeriadoCommand>(_unitOfWork));
        }
    }
}