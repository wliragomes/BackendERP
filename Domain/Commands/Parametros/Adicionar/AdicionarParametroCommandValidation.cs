using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Parametros.Adicionar
{
    public class AdicionarParametroCommandValidation : AbstractValidator<AdicionarParametroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarParametroCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ParametroCommandValidation<AdicionarParametroCommand>(_unitOfWork));
        }
    }
}
