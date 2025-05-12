using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Prateleiras.Excluir
{
    public class ExcluirPrateleiraCommand : CommandInBulk<ExcluirPrateleiraCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
