using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Ncms.Adicionar
{
    public class AdicionarNcmCommandValidation : AbstractValidator<AdicionarNcmCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarNcmCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new NcmCommandValidation<AdicionarNcmCommand>(_unitOfWork));
        }
    }
}
