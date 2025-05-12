using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Vendas.Adicionar
{
    public class AdicionarVendaCommandValidation : AbstractValidator<AdicionarVendaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarVendaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
                .SetValidator(new VendaCommandValidation<AdicionarVendaCommand>(_unitOfWork));
        }
    }
}
