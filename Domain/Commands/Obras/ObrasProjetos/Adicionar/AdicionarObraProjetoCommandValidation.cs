using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ObrasProjetos.Adicionar
{
    public class AdicionarObraProjetoCommandValidation : AbstractValidator<AdicionarObraProjetoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarObraProjetoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ObraProjetoCommandValidation<AdicionarObraProjetoCommand>(_unitOfWork));
        }
    }
}
