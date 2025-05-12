using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Pessoas.TipoConsumidores.Atualizar
{
    public class AtualizarTipoConsumidorCommandValidation : AbstractValidator<AtualizarTipoConsumidorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarTipoConsumidorCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new TipoConsumidorCommandValidation<AtualizarTipoConsumidorCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ExisteIdNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ExisteIdNoDB(Guid? id)
        {
            return id.HasValue && await _unitOfWork.TipoConsumidorRepository.ExisteIdAsync(id.Value);
        }
    }
}

