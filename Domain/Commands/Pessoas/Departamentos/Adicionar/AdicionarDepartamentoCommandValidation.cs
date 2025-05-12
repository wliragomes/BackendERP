using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Departamentos.Adicionar
{
    public class AdicionarDepartamentoCommandValidation : AbstractValidator<AdicionarDepartamentoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarDepartamentoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new DepartamentoCommandValidation<AdicionarDepartamentoCommand>(_unitOfWork));
        }
    }
}
