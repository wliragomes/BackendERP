using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MedidaJumbo : EntityId
    {
        public int? Ordem { get; set; }
        public bool Habilitar { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }

        public MedidaJumbo(int? ordem, bool habilitar, decimal altura, decimal largura)
        {
            SetId(Guid.NewGuid());
            Ordem = ordem;
            Habilitar = habilitar;
            Altura = altura;
            Largura = largura;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int? ordem, bool habilitar, decimal altura, decimal largura)
        {
            Ordem = ordem;
            Habilitar = habilitar;
            Altura = altura;
            Largura = largura;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
