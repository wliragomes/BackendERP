using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Chapa : EntityIdDescricao
    {
        public int Altura { get; set; }
        public int Largura { get; set; }

        public Chapa(string descricao, int altura, int largura)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);
            Altura = altura;
            Largura = largura;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao, int altura, int largura)
        {
            SetDescricao(descricao);
            Altura = altura;
            Largura = largura;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
