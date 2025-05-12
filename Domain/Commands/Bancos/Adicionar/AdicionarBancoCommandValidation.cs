using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Bancos.Adicionar
{
    public class AdicionarBancoCommandValidation : AbstractValidator<AdicionarBancoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarBancoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new BancoCommandValidation<AdicionarBancoCommand>(_unitOfWork));
        }
    }
}
