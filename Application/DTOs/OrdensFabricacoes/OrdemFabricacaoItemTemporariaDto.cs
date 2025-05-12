namespace Application.DTOs.OrdensFabricacoes
{
    public class OrdemFabricacaoItemTemporariaDto
    {
        public Guid IdVenda { get; set; }
        public int SqVendaItem { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal ValorM2 { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorPeso { get; set; }
        public decimal ValorMLinearReal { get; set; }
        public decimal ValorMLinear { get; set; }
    }
}
