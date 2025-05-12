namespace Application.DTOs.Produtos.DesgastePolimentos.Filtro
{
    public class DesgastePolimentoFilterDto
    {
        public Guid Id { get; set; }
        public decimal EspessuraVidroMinimo { get; set; }
        public decimal EspessuraVidroMaximo { get; set; }
        public decimal QuantidadeDesgasteLado { get; set; }
        public decimal QuantidadeDesgasteTotal { get; set; }

    }
}
