using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.TiposRodados.Adicionar
{
    public class AdicionarTipoRodadoCommandValidation : AbstractValidator<AdicionarTipoRodadoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarTipoRodadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new TipoRodadoCommandValidation<AdicionarTipoRodadoCommand>(_unitOfWork));
        }
    }
}
