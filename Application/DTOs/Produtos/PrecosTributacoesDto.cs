namespace Application.DTOs.Produtos
{
    public class PrecosTributacoesDto
    {
        public Guid IdNcm { get; set; }
        public string? NrNcmCompleta { get; set; }
        public Guid IdOrigemMaterial { get; set; }
        public Guid IdTipoPreco { get; set; }
        public Guid IdClasseReajuste { get; set; }
        public decimal? Ipi { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoVenda { get; set; }               
        public bool? Inativo { get; set; }               
    }
}
