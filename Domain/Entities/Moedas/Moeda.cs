using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Moeda : EntityIdNome
    {
        public bool Negociavel { get; private set; }

        public Moeda(string nome, bool negociavel)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            Negociavel = negociavel;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, bool negociavel)
        {
            SetNome(nome);
            Negociavel = negociavel;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
