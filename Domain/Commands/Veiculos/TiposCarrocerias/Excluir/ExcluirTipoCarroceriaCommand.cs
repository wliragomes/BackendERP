using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.TiposCarrocerias.Excluir
{
    public class ExcluirTipoCarroceriaCommand : CommandInBulk<ExcluirTipoCarroceriaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
