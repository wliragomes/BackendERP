using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Subgrupos.Excluir
{
    public class ExcluirSubgrupoCommand : CommandInBulk<ExcluirSubgrupoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
