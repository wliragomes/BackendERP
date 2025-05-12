using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class MotivoReposicao : EntityIdDescricao
    {        

        public MotivoReposicao(string descricao)
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
