namespace Application.DTOs.Produtos
{
    public class ComposicaoDto
    {
        public Guid IdProduto { get; set; }
        public string? codigoAmigavel { get; set; }
        public string? nome { get; set; }
        public int? SequenciaComposicao { get; set; }
        public int? PerfilH { get; set; }
        public int? PerfilL { get; set; }
        public bool? Etiqueta { get; set; }        
    }
}