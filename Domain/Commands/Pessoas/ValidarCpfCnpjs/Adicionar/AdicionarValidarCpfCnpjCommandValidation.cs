using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ValidarCpfCnpjs.Adicionar
{
    public class AdicionarValidarCpfCnpjCommandValidation : AbstractValidator<AdicionarValidarCpfCnpjCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarValidarCpfCnpjCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ValidarCpfCnpjCommandValidation<AdicionarValidarCpfCnpjCommand>(_unitOfWork));
        }
    }
}
