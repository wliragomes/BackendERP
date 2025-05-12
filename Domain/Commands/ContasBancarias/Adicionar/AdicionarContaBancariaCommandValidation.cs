using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasBancarias.Adicionar
{
    public class AdicionarContaBancariaCommandValidation : AbstractValidator<AdicionarContaBancariaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarContaBancariaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ContaBancariaCommandValidation<AdicionarContaBancariaCommand>(_unitOfWork));
        }
    }
}
