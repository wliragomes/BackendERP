using SharedKernel.SharedObjects;

namespace Domain.Entities.Telefones
{
    public class TipoTelefone : EntityIdDescricao
    {
        public ICollection<Telefone>? Telefones { get; private set; }

        public TipoTelefone(string descricao)
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
