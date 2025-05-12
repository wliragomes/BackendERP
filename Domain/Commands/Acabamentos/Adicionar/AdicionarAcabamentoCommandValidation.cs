using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Acabamentos.Adicionar
{
    public class AdicionarAcabamentoCommandValidation : AbstractValidator<AdicionarAcabamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarAcabamentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new AcabamentoCommandValidation<AdicionarAcabamentoCommand>(_unitOfWork));
        }
    }
}
