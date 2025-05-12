using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.Representantes.Atualizar
{
    public class AtualizarRepresentanteCommandValidation : AbstractValidator<AtualizarRepresentanteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarRepresentanteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
            .SetValidator(new RepresentanteCommandValidation<AtualizarRepresentanteCommand>(_unitOfWork));
        }
    }
}
