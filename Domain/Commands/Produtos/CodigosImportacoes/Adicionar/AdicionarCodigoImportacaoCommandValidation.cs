using Domain.Interfaces.Repositories;
using FluentValidation;

namespace Domain.Commands.Produtos.CodigosImportacoes.Adicionar
{
    public class AdicionarCodigoImportacaoCommandValidation : AbstractValidator<AdicionarCodigoImportacaoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdicionarCodigoImportacaoCommandValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c)
                .SetValidator(new CodigoImportacaoCommandValidation<AdicionarCodigoImportacaoCommand>(_unitOfWork));
        }
    }
}
