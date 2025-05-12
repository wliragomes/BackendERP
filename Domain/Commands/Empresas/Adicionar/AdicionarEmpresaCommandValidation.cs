using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Empresas.Adicionar
{
    public class AdicionarEmpresaCommandValidation : AbstractValidator<AdicionarEmpresaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarEmpresaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new EmpresaCommandValidation<AdicionarEmpresaCommand>(_unitOfWork));
        }
    }
}
