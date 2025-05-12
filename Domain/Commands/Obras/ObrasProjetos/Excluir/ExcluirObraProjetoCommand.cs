using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ObrasProjetos.Excluir
{
    public class ExcluirObraProjetoCommand : CommandInBulk<ExcluirObraProjetoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
