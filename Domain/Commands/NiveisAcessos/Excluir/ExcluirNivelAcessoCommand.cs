using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.NiveisAcessos.Excluir
{
    public class ExcluirNivelAcessoCommand : CommandInBulk<ExcluirNivelAcessoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
