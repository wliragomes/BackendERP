namespace Application.DTOs.PlanejamentoProducoes
{
    public class PlanejamentoProducaoDto
    {
        public Guid? IdOrdemFabricacao { get; set; }
        public Guid? IdOrdemFabricacaoItem { get; set; }
        public Guid? IdComposicao { get; set; }
        public int? SequenciaComposicacao { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public int? NPeca { get; set; }
        public int? QtdTotalPeca { get; set; }
        public string? CodigoBarra { get; set; }
        public string? AnoBarra { get; set; }
        public string? CodigoBarraCompleto { get; set; }
        public decimal? ValorM2 { get; set; }
        public decimal? ValorMLinear { get; set; }
        public decimal? ValorPeso { get; set; }
        public decimal? ValorM2Real { get; set; }
        public decimal? ValorMLinearReal { get; set; }
        public decimal? ValorPesoReal { get; set; }
        public decimal? ValorAreaMinima { get; set; }
        public Guid? IdSetorProduto { get; set; }
        public decimal? AlturaLapidacao { get; set; }
        public decimal? LarguraLapidacao { get; set; }
        public DateTime? DataReposicao { get; set; }
        public Guid? IdPlanejamentoComposto { get; set; }
        public bool? Reposicao { get; set; }
        public bool? Reposto { get; set; }
    }
}
