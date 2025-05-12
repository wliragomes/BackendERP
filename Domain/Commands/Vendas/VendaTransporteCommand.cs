using Domain.Commands.Faturas;

namespace Domain.Commands.Vendas
{
    public class VendaTransporteCommand : FaturaTransporteCommand
    {
        public bool? Retira { get; set; }
        public bool? Entrega { get; set; }
        public DateTime? InicioEntrega { get; set; }
        public DateTime? TerminoEntrega { get; set; }
        public int? FretesPrevistos { get; set; }
        public decimal? ValorFrete { get; set; }
        public bool? ComFrete { get; set; }
        public string? DetalhesFrete { get; set; }
    }
}
