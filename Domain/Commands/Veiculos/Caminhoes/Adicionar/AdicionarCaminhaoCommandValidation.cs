using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Caminhoes.Adicionar
{
    public class AdicionarCaminhaoCommandValidation : AbstractValidator<AdicionarCaminhaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCaminhaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CaminhaoCommandValidation<AdicionarCaminhaoCommand>(_unitOfWork));
        }
    }
}
