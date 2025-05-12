using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Projetos.Excluir
{
    public class ExcluirProjetoCommand : CommandInBulk<ExcluirProjetoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
