using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Prateleiras.Adicionar
{
    public class AdicionarPrateleiraCommandValidation : AbstractValidator<AdicionarPrateleiraCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarPrateleiraCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new PrateleiraCommandValidation<AdicionarPrateleiraCommand>(_unitOfWork));
        }
    }
}
