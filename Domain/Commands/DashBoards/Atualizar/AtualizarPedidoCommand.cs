using Domain.Commands.Pedidos;

namespace Domain.Commands.Vendas.Atualizar
{
    public class AtualizarPedidoCommand : PedidoCommand<AtualizarPedidoCommand>
    {


        public AtualizarPedidoCommand(Guid id, Guid idStatus)
    : base(id, idStatus)
        { }

        public AtualizarPedidoCommand()
        {
        }
    }
}
