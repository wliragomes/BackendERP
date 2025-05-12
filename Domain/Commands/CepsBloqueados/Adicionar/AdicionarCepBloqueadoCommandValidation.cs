using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.CepsBloqueados.Adicionar
{
    public class AdicionarCepBloqueadoCommandValidation : AbstractValidator<AdicionarCepBloqueadoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCepBloqueadoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CepBloqueadoCommandValidation<AdicionarCepBloqueadoCommand>(_unitOfWork));
        }
    }
}
