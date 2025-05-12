using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FaturaTemporarias.Adicionar
{
    public class AdicionarFaturaTemporariaCommandValidation : AbstractValidator<AdicionarFaturaTemporariaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFaturaTemporariaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FaturaTemporariaCommandValidation<AdicionarFaturaTemporariaCommand>(_unitOfWork));
        }
    }
}
