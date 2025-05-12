namespace Application.DTOs.OrdensFabricacoes
{
    public class OrdemFabricacaoItemDto
    {
        public int? SqItem { get; set; }
        public int? SqVendaItem { get; set; }
        public Guid? IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public string? DescricaoProduto { get; set; }
        public decimal? Espessura { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public int? Quantidade { get; set; }
        public bool? Aramado { get; set; }
        public bool? Modelado { get; set; }
        public decimal? ValorM2 { get; set; }
        public decimal? ValorM { get; set; }
        public decimal? ValorPeso { get; set; }
        public decimal? ValorM2Real { get; set; }
        public decimal? ValorMReal { get; set; }
        public decimal? ValorPesoReal { get; set; }
        public decimal? ValorAreaMinima { get; set; }
        public Guid? IdSetorProduto { get; set; }
        public Guid? IdProjeto { get; set; }
        public decimal? AlturaLapidacao { get; set; }
        public decimal? LarguraLapidacao { get; set; }
        public bool? Manual { get; set; }
        public bool? Cortado { get; set; }
        public bool? Filete1 { get; set; }
        public bool? Filete2 { get; set; }
        public bool? Filete3 { get; set; }
        public bool? Filete4 { get; set; }
        public bool? Industrial1 { get; set; }
        public bool? Industrial2 { get; set; }
        public bool? Industrial3 { get; set; }
        public bool? Industrial4 { get; set; }
        public bool? Polida1 { get; set; }
        public bool? Polida2 { get; set; }
        public bool? Polida3 { get; set; }
        public bool? Polida4 { get; set; }
        public bool? QuebraCanto { get; set; }
        public bool? Revenda { get; set; }
        public bool? Instalacao { get; set; }
        public bool? ManterEdgeDeletion { get; set; }
        public bool? CancelarEdgeDeletion { get; set; }

    }
}
