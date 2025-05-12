using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.TiposPrecos.Excluir
{
    public class ExcluirTipoPrecoCommand : CommandInBulk<ExcluirTipoPrecoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
