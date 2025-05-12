using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class FusoHorario : EntityId
    {
        public string NumeroFusoHorario { get; private set; }

        public FusoHorario(string numeroFusoHorario)
        {
            SetId(Guid.NewGuid());
            NumeroFusoHorario = numeroFusoHorario;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string numeroFusoHorario)
        {
            NumeroFusoHorario = numeroFusoHorario;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
