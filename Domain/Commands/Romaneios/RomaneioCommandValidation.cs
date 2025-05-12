using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Romaneios
{
    public class RomaneioCommandValidation<T> : AbstractValidator<RomaneioCommand<T>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RomaneioCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
