using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Cidades.Adicionar
{
    public class AdicionarCidadeCommandValidation : AbstractValidator<AdicionarCidadeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            RuleFor(c => c)
                .SetValidator(new CidadeCommandValidation<AdicionarCidadeCommand>(_unitOfWork));
        }
    }
}
