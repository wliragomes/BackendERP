using Domain.Constant;
using Domain.Constants;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Comissoes
{
    public class ComissaoCommandValidation<T> : AbstractValidator<ComissaoCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ComissaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
