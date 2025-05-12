using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.MotivoReposições.Adicionar
{
    public class AdicionarMotivoReposicaoCommandValidation : AbstractValidator<AdicionarMotivoReposicaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarMotivoReposicaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new MotivoReposicaoCommandValidation<AdicionarMotivoReposicaoCommand>(_unitOfWork));
        }
    }
}
