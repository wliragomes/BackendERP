using Domain.Commands.Classificacoes;
using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Classificacoes.Adicionar
{
    public class AdicionarClassificacaoCommandValidation : AbstractValidator<AdicionarClassificacaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarClassificacaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new ClassificacaoCommandValidation<AdicionarClassificacaoCommand>(_unitOfWork));
        }
    }
}
