using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Grupos.Adicionar
{
    public class AdicionarGrupoCommandValidation : AbstractValidator<AdicionarGrupoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarGrupoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new GrupoCommandValidation<AdicionarGrupoCommand>(_unitOfWork));
        }
    }
}
