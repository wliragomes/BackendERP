using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Pessoas.Excluir
{
    public class ExcluirPessoaCommand : CommandInBulk<ExcluirPessoaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}

