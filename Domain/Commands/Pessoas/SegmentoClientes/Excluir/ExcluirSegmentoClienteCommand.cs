using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoClientes.Excluir
{
    public class ExcluirSegmentoClienteCommand : CommandInBulk<ExcluirSegmentoClienteCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
