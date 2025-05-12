using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Banco : EntityIdNome
    {
        public bool NaoSomar { get; private set; }
        public string NumeroBanco { get; private set; }
        public virtual FluxoCaixa FluxoCaixa { get; set; }
        public Banco(string nome, bool naoSomar, string numeroBanco)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            NaoSomar = naoSomar;
            NumeroBanco = numeroBanco;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string nome, bool naoSomar, string numeroBanco)
        {
            SetNome(nome);
            NaoSomar = naoSomar;
            NumeroBanco = numeroBanco;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
