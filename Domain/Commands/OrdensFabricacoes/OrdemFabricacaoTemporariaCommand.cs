using SharedKernel.MediatR;

namespace Domain.Commands.OrdensFabricacoes
{
    public class OrdemFabricacaoTemporariaCommand<T> : CommandBase<T>
    {
        public List<OrdemFabricacaoItemTemporariaCommand>? OrdemFabricacaoItemTemporaria { get; set; }

        public OrdemFabricacaoTemporariaCommand()
        {

        }
    }
}