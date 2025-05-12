namespace Domain.Commands.Produtos
{
    public class ComposicaoCommand
    {
        public Guid IdProduto { get; set; }
        public int? SequenciaComposicao { get; set; }
        public int? PerfilH { get; set; }
        public int? PerfilL { get; set; }
        public bool? Etiqueta { get; set; }
        

    }
}
