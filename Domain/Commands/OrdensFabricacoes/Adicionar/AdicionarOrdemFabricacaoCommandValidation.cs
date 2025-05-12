using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.OrdensFabricacoes.Adicionar
{
    public class AdicionarOrdemFabricacaoCommandValidation : AbstractValidator<AdicionarOrdemFabricacaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarOrdemFabricacaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new OrdemFabricacaoCommandValidation<AdicionarOrdemFabricacaoCommand>(_unitOfWork));
        }
    }
}
