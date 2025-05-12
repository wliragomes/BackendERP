using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarOrdemFabricacaoTemporariaCommandValidation : AbstractValidator<AdicionarOrdemFabricacaoTemporariaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarOrdemFabricacaoTemporariaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new OrdemFabricacaoTemporariaCommandValidation<AdicionarOrdemFabricacaoTemporariaCommand>(_unitOfWork));
        }
    }
}
