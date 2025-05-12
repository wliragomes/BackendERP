using SharedKernel.SharedObjects;

namespace Domain.Entities.Enderecos
{
    public class TipoEndereco : EntityIdDescricao
    {
        public ICollection<Endereco>? Enderecos { get; private set; }

        public TipoEndereco(string descricao)
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
