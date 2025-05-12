using Domain.Commands.Romaneios;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarRomaneioCommandValidation : AbstractValidator<AdicionarRomaneioCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarRomaneioCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new RomaneioCommandValidation<AdicionarRomaneioCommand>(_unitOfWork));
        }
    }
}
