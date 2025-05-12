using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Duplicatas.Adicionar
{
    public class AdicionarDuplicataCommandValidation : AbstractValidator<AdicionarDuplicataCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarDuplicataCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new DuplicataCommandValidation<AdicionarDuplicataCommand>(_unitOfWork));
        }
    }
}
