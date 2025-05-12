using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Acabamento : EntityId
    {
        public string Descricao { get; set; }
        public bool Tolerancia { get; set; }

        public Acabamento(string descricao, bool tolerancia)
        {
            SetId(Guid.NewGuid());
            Descricao = descricao;
            Tolerancia = tolerancia;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string descricao, bool tolerancia)
        {
            Descricao = descricao;
            Tolerancia = tolerancia;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
