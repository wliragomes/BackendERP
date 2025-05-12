using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.FaturaTemporarias
{
    public class FaturaTemporariaCommandValidation<T> : AbstractValidator<FaturaTemporariaCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FaturaTemporariaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            
        }       
    }
}
