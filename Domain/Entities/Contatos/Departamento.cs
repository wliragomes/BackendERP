using SharedKernel.SharedObjects;

namespace Domain.Entities.Contatos
{
    public class Departamento : EntityIdNome
    {
        public ICollection<Contato>? Contatos { get; private set; }

        public Departamento() { }

        public Departamento(string nome)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome)
        {
            SetNome(nome);

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
