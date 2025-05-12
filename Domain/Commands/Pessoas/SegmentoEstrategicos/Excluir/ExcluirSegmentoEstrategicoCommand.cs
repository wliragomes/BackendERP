using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.SegmentoEstrategicos.Excluir
{
    public class ExcluirSegmentoEstrategicoCommand : CommandInBulk<ExcluirSegmentoEstrategicoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
