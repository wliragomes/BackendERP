using SharedKernel.SharedObjects;

namespace Domain.Entities.Emails
{
    public class TipoEmail : EntityIdDescricao
    {
        public ICollection<Email>? Emails { get; private set; }

        public TipoEmail(string descricao)
        {
            SetId(Guid.NewGuid());
            SetDescricao(descricao);
            
            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao)
        {
            SetDescricao(descricao);

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
