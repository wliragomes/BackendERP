using SharedKernel.MediatR;
using SharedKernel.SharedObjects;

namespace Domain.Commands.Vendas.Excluir
{
    public class ExcluirVendaCommand : CommandInBulk<ExcluirVendaCommand>
    {
        public FiltroBase FiltroBase { get; protected set; }        
    }
}
