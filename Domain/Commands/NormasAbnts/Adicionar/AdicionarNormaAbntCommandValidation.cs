using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.NormasAbnts.Adicionar
{
    public class AdicionarNormaAbntCommandValidation : AbstractValidator<AdicionarNormaAbntCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarNormaAbntCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new NormaAbntCommandValidation<AdicionarNormaAbntCommand>(_unitOfWork));
            
        }
    }    
}
