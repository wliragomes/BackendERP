using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.Grupos.Excluir
{
    public class ExcluirGrupoCommand : CommandInBulk<ExcluirGrupoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
