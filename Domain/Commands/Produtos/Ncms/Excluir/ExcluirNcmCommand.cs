using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Ncms.Excluir
{
    public class ExcluirNcmCommand : CommandInBulk<ExcluirNcmCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
