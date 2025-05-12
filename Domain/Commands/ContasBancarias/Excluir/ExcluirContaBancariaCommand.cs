using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.ContasBancarias.Excluir
{
    public class ExcluirContaBancariaCommand : CommandInBulk<ExcluirContaBancariaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
