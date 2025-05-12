using Application.DTOs.Faturas;
using Application.DTOs.Pessoas;

namespace Application.DTOs.Vendas.Filtro
{
    public class VendaOfRomaneioDto
    {
        public Guid Id { get; set; }
        public int CodigoVenda { get; set; }
        public int AnoVenda { get; set; }
        public decimal? PrecoCadaFrete { get; set; }
        public int? FretesPrevistos { get; set; }
        public int? QtdFretePorRomaneio { get; set; }
    }
}
