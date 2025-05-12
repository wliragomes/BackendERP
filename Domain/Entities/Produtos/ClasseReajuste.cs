using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class ClasseReajuste : EntityIdNome
    {
        public string Descricao { get; set; }

        public ClasseReajuste(string nome, string descricao)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            Descricao = descricao;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, string descricao)
        {
            SetNome(nome);
            Descricao = descricao;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
