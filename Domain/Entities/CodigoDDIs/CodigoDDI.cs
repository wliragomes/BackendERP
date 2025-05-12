using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class CodigoDDI : EntityId
    {
        public string Codigo { get; private set; }

        public CodigoDDI(string codigo)
        {
            SetId(Guid.NewGuid());
            Codigo = codigo;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string codigo)
        {
            Codigo = codigo;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
