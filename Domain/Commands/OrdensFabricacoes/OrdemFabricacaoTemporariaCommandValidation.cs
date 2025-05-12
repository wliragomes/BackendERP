using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.OrdensFabricacoes
{
    public class OrdemFabricacaoTemporariaCommandValidation<T> : AbstractValidator<OrdemFabricacaoTemporariaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdemFabricacaoTemporariaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
