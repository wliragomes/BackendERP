using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ObrasPadrao.Adicionar
{
    public class AdicionarObraPadraoCommandValidation : AbstractValidator<AdicionarObraPadraoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarObraPadraoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ObraPadraoCommandValidation<AdicionarObraPadraoCommand>(_unitOfWork));
        }
    }
}
