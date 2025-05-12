using Domain.Entities.Emails;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaPessoaEmail : Entity
    {
        public Guid IdPessoa { get; private set; }
        public Pessoa? Pessoa { get; private set; }
        public Guid IdEmail { get; private set; }
        public Email? Email { get; private set; }

        public RelacionaPessoaEmail() { }

        public RelacionaPessoaEmail(Guid idPessoa, Guid idEmail)
        {
            IdPessoa = idPessoa;
            IdEmail = idEmail;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPessoa, Guid idEmail)
        {
            IdPessoa = idPessoa;
            IdEmail = idEmail;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
