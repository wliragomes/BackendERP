using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Representantes.Adicionar
{
    public class AdicionarRepresentanteCommandValidation : AbstractValidator<AdicionarRepresentanteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarRepresentanteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new RepresentanteCommandValidation<AdicionarRepresentanteCommand>(_unitOfWork));
        }
    }
}
