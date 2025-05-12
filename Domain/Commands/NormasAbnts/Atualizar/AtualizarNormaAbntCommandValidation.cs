using Domain.Interfaces.Repositories;
using FluentValidation;
using SharedKernel.Utils.Constants;

namespace Domain.Commands.NormasAbnts.Atualizar
{
    public class AtualizarNormaAbntCommandValidation : AbstractValidator<AtualizarNormaAbntCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtualizarNormaAbntCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
               .SetValidator(new NormaAbntCommandValidation<AtualizarNormaAbntCommand>(_unitOfWork));

            RuleFor(c => c.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage(ConstantGeneral.REQUIRED_FIELD)
                .MustAsync(async (s, cancellation) => await ChecklistExisteNoDB(s))
                .WithMessage(ConstantGeneral.NOT_FOUND);
        }

        private async Task<bool> ChecklistExisteNoDB(Guid? id)
        {
            var idChecklist = id ?? Guid.Empty;
            if (idChecklist == Guid.Empty)
                return false;


            return await _unitOfWork.NormaAbntRepository.ExisteIdAsync(idChecklist);
        }
    }
}
