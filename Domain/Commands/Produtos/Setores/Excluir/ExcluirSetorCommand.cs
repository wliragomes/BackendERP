using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Setores.Excluir
{
    public class ExcluirSetorCommand : CommandInBulk<ExcluirSetorCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
