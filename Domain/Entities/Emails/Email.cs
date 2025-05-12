using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Emails
{
    public class Email : EntityId
    {
        public Guid IdTipoEmail { get; private set; }
        public string EnderecoEmail { get; private set; }
        public TipoEmail TiposEmail { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        public ICollection<RelacionaPessoaEmail> RelacionaPessoaEmails { get; private set; }

        public Email() { }

        public Email(Guid idTipoEmail, string enderecoEmail)
        {
            SetId(Guid.NewGuid());
            IdTipoEmail = idTipoEmail;
            EnderecoEmail = enderecoEmail;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idTipoEmail, string enderecoEmail)
        {
            IdTipoEmail = idTipoEmail;
            EnderecoEmail = enderecoEmail;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
