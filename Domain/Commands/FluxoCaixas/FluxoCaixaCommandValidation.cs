using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FluxoCaixas
{
    public class FluxoCaixaCommandValidation<T> : AbstractValidator<FluxoCaixaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FluxoCaixaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;            
        }
    }
}
