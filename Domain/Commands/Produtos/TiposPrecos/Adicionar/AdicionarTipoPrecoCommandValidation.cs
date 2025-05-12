using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.TiposPrecos.Adicionar
{
    public class AdicionarTipoPrecoCommandValidation : AbstractValidator<AdicionarTipoPrecoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarTipoPrecoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new TipoPrecoCommandValidation<AdicionarTipoPrecoCommand>(_unitOfWork));
        }
    }
}
