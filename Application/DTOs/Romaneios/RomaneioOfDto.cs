namespace Application.DTOs.Romaneios
{
    public class RomaneioOfDto
    {
        public int? SqRomaneioCodigo { get; set; }
        public int? SqRomaneioAno { get; set; }
        public int? SqOrdemFabricacaoCodigo { get; set; }
        public int? SqOrdemFabricacaoAno { get; set; }
        public Guid? IdPessoa { get; set; }
        public string? RazaoSocial { get; set; }
        public decimal? QtdPeca { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public decimal? Peso { get; set; }
        public decimal? AreaTotal { get; set; }
    }
}
