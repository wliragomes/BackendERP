using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Projetos.Adicionar
{
    public class AdicionarProjetoCommandValidation : AbstractValidator<AdicionarProjetoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarProjetoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ProjetoCommandValidation<AdicionarProjetoCommand>(_unitOfWork));
        }
    }
}
