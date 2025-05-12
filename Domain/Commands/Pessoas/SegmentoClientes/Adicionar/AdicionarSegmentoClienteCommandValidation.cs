using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.SegmentoClientes.Adicionar
{
    public class AdicionarSegmentoClienteCommandValidation : AbstractValidator<AdicionarSegmentoClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarSegmentoClienteCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new SegmentoClienteCommandValidation<AdicionarSegmentoClienteCommand>(_unitOfWork));
        }
    }
}