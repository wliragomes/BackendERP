using Domain.Entities.Telefones;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaPessoaTelefone : Entity
    {
        public Guid IdPessoa { get; private set; }
        public Pessoa? Pessoa { get; private set; }
        public Guid IdTelefone { get; private set; }
        public Telefone? Telefone { get; private set; }

        public RelacionaPessoaTelefone() { }

        public RelacionaPessoaTelefone(Guid idPessoa, Guid idTelefone)
        {
            IdPessoa = idPessoa;
            IdTelefone = idTelefone;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPessoa, Guid idTelefone)
        {
            IdPessoa = idPessoa;
            IdTelefone = idTelefone;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
