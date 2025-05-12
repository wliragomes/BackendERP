using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.Ruas.Adicionar
{
    public class AdicionarRuaCommandValidation : AbstractValidator<AdicionarRuaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarRuaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new RuaCommandValidation<AdicionarRuaCommand>(_unitOfWork));
        }
    }
}
