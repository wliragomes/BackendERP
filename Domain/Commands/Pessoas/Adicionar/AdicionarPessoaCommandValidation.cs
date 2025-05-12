using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Pessoas.Adicionar
{
    public class AdicionarPessoaCommandValidation : AbstractValidator<AdicionarPessoaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarPessoaCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c)
                .SetValidator(new PessoaCommandValidation<AdicionarPessoaCommand>(_unitOfWork));
        }
    }
}
