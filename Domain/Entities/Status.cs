using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Status : EntityIdDescricao
    {
        public int Numero { get; set; }
        public Status() { }

        public Status(int numero, string descricao)
        {
            SetId(Guid.NewGuid());            
            SetDescricao(descricao);
            Numero = numero;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int numero, string descricao)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);
            Numero = numero;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
