using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FusoHorarios.Adicionar
{
    public class AdicionarFusoHorarioCommandValidation : AbstractValidator<AdicionarFusoHorarioCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFusoHorarioCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FusoHorarioCommandValidation<AdicionarFusoHorarioCommand>(_unitOfWork));
        }
    }
}
