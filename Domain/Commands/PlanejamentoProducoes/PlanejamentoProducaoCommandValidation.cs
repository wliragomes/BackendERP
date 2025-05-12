using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.PlanejamentoProducaos
{
    public class PlanejamentoProducaoCommandValidation<T> : AbstractValidator<PlanejamentoProducaoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlanejamentoProducaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
