using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Comissoes.Adicionar
{
    public class AdicionarComissaoCommandValidation : AbstractValidator<AdicionarComissaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarComissaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ComissaoCommandValidation<AdicionarComissaoCommand>(_unitOfWork));
        }
    }
}
