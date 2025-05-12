namespace Domain.Commands.Produtos
{
    public class PrecosTributacoesCommand
    {
        public Guid IdNcm { get; set; }
        public Guid IdOrigemMaterial { get; set; }
        public Guid IdTipoPreco { get; set; }
        public Guid IdClasseReajuste { get; set; }
        public decimal? PrecoCusto { get; set; }
        public decimal? PrecoVenda { get; set; }
        public bool? Inativo { get; set; }
    }
}
