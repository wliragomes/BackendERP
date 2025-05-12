using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Familias.Excluir
{
    public class ExcluirFamiliaCommand : CommandInBulk<ExcluirFamiliaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
