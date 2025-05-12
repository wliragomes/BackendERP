using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.DesgastePolimentos.Excluir
{
    public class ExcluirDesgastePolimentoCommand : CommandInBulk<ExcluirDesgastePolimentoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
