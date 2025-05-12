using SharedKernel.MediatR;

namespace Domain.Commands.NormasAbnts
{
    public abstract class NormaAbntCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string? NNbr { get; set; }
        public string? Descricao { get; set; }
        public string? Pedido { get; set; }
        public DateTime? Validade { get; set; }
        public bool Vencida { get; set; }

        public NormaAbntCommand() { }

        public NormaAbntCommand(Guid id, string? nnbr, string? descricao, string? pedido, DateTime? validade, bool vencida)
        {
            Id = id;
            NNbr = nnbr;
            Descricao = descricao;
            Pedido = pedido;
            Validade = validade;
            Vencida = vencida;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}