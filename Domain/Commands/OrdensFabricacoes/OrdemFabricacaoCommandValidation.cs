using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.OrdensFabricacoes
{
    public class OrdemFabricacaoCommandValidation<T> : AbstractValidator<OrdemFabricacaoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdemFabricacaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
    }
}
