namespace Application.DTOs.Parametros
{
    public class MedidaJumboDto
    {
        public Guid Id { get; set; }
        public int? Ordem { get; set; }
        public bool Habilitar { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
    }
}
