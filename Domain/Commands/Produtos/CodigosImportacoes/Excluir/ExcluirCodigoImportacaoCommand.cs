using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Produtos.CodigosImportacoes.Excluir
{
    public class ExcluirCodigoImportacaoCommand : CommandInBulk<ExcluirCodigoImportacaoCommand>
    {
        public FiltroBase FiltroBase { get; protected set; } = new FiltroBase();
    }
}
