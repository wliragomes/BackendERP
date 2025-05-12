using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.TipoFretes.Adicionar
{
    public class AdicionarTipoFreteCommandValidation : AbstractValidator<AdicionarTipoFreteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarTipoFreteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new TipoFreteCommandValidation<AdicionarTipoFreteCommand>(_unitOfWork));
        }
    }
}
