namespace Domain.Commands.MedidasJumbo
{
    public class MedidaJumboCommand
    {
        public Guid Id { get; set; }
        public int? Ordem { get; set; }
        public bool Habilitar { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public MedidaJumboCommand()
        {

        }

        public MedidaJumboCommand(Guid id, int ordem, bool habilitar, decimal altura, decimal largura)
        {
            Id = id;
            Ordem = ordem;
            Habilitar = habilitar;
            Altura = altura;
            Largura = largura;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}