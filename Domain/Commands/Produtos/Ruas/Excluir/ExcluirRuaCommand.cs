using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ruas.Excluir
{
    public class ExcluirRuaCommand : CommandInBulk<ExcluirRuaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
