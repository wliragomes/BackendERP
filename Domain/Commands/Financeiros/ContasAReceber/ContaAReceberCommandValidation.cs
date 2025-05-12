using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.ContasAReceber
{
    public class ContaAReceberCommandValidation<T> : AbstractValidator<ContaAReceberCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContaAReceberCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
