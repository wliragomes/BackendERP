using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.ClasseReajustes.Excluir
{
    public class ExcluirClasseReajusteCommand : CommandInBulk<ExcluirClasseReajusteCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase(); 
    }
}
