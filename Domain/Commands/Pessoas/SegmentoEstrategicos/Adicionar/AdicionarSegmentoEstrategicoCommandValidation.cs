using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.SegmentoEstrategicos.Adicionar
{
    public class AdicionarSegmentoEstrategicoCommandValidation : AbstractValidator<AdicionarSegmentoEstrategicoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarSegmentoEstrategicoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new SegmentoEstrategicoCommandValidation<AdicionarSegmentoEstrategicoCommand>(_unitOfWork));
        }
    }
}