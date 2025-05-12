using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Setores.Adicionar
{
    public class AdicionarSetorCommandValidation : AbstractValidator<AdicionarSetorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarSetorCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new SetorCommandValidation<AdicionarSetorCommand>(_unitOfWork));
        }
    }
}
