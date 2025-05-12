using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Feriado : EntityIdNome
    {
        public DateTime Data { get; set; }

        public Feriado(string nome, DateTime data)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            Data = data;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, DateTime data)
        {
            SetNome(nome);
            Data = data;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
