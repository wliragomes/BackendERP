using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Representante : EntityId
    {
        public Guid IdPessoa { get; private set; }
        public bool Externo { get; private set; }
        public decimal Comissao { get; private set; }

        public Representante(Guid idPessoa, bool externo, decimal comissao)
        {
            SetId(new Guid());
            IdPessoa = idPessoa;
            Externo = externo;
            Comissao = comissao;

            SetId(new Guid());
            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPessoa, bool externo, decimal comissao)
        {
            IdPessoa = idPessoa;
            Externo = externo;
            Comissao = comissao;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
