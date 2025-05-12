using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Modalidades.Adicionar
{
    public class AdicionarModalidadeCommandValidation : AbstractValidator<AdicionarModalidadeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarModalidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ModalidadeCommandValidation<AdicionarModalidadeCommand>(_unitOfWork));
        }
    }
}
