using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.NiveisAcessos.Adicionar
{
    public class AdicionarNivelAcessoCommandValidation : AbstractValidator<AdicionarNivelAcessoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarNivelAcessoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new NivelAcessoCommandValidation<AdicionarNivelAcessoCommand>(_unitOfWork));
        }
    }
}
