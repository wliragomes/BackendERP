using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Funcionalidades.Adicionar
{
    public class AdicionarFuncionalidadeCommandValidation : AbstractValidator<AdicionarFuncionalidadeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarFuncionalidadeCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new FuncionalidadeCommandValidation<AdicionarFuncionalidadeCommand>(_unitOfWork));
        }
    }
}
