using Domain.Entities.Contatos;
using Domain.Entities.Telefones;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaPessoaContatoTelefone : Entity
    {
        public Guid IdContato { get; private set; }
        public Contato? Contato { get; private set; }
        public Guid IdTelefone { get; private set; }
        public Telefone? Telefone { get; private set; }

        public RelacionaPessoaContatoTelefone() { }

        public RelacionaPessoaContatoTelefone(Guid idContato, Guid idTelefone)
        {
            IdContato = idContato;
            IdTelefone = idTelefone;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idContato, Guid idTelefone)
        {
            IdContato = idContato;
            IdTelefone = idTelefone;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
