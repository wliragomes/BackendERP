using SharedKernel.SharedObjects;

namespace Domain.Entities.Contatos
{
    public class Cargo : EntityIdNome
    {
        public ICollection<Contato>? Contatos { get; private set; }

        public Cargo() { }

        public Cargo(string descricao)
        {
            SetId(Guid.NewGuid());
            SetNome(descricao);

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao)
        {
            SetNome(descricao);
            ChangeUpdateAtToDateTimeNow();
        }
    }
}
