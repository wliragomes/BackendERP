using SharedKernel.MediatR;

namespace Domain.Commands.Pedidos
{
    public class PedidoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid IdStatus { get; set; }

        public PedidoCommand()
        {

        }

        public PedidoCommand(Guid id, Guid idStatus)
        {
            Id = id;
            IdStatus = idStatus;
        }
    }
}