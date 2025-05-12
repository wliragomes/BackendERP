using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FaturaParametros.Adicionar
{
    public class AdicionarFaturaParametroCommandValidation : AbstractValidator<AdicionarFaturaParametroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFaturaParametroCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FaturaParametroCommandValidation<AdicionarFaturaParametroCommand>(_unitOfWork));
        }
    }
}
