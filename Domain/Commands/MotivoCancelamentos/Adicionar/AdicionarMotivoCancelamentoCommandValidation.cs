using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.MotivoCancelamentos.Adicionar
{
    public class AdicionarMotivoCancelamentoCommandValidation : AbstractValidator<AdicionarMotivoCancelamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarMotivoCancelamentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new MotivoCancelamentoCommandValidation<AdicionarMotivoCancelamentoCommand>(_unitOfWork));
        }
    }
}
