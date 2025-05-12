namespace Application.DTOs.MotivoCancelamentos
{
    public class MotivoCancelamentoByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Pedido { get; set; }
        public bool Orcamento { get; set; }
        public bool PedidoInativo { get; set; }
        public bool OrcamentoInativo { get; set; }

    }
}
