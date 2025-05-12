using Domain.Entities.Telefones;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaDadosCobrancaTelefone : Entity
    {
        public Guid IdDadosCobranca { get; private set; }
        public DadosCobranca? DadosCobranca { get; private set; }
        public Guid IdTelefone { get; private set; }
        public Telefone? Telefone { get; private set; }

        public RelacionaDadosCobrancaTelefone() { }

        public RelacionaDadosCobrancaTelefone(Guid idDadosCobranca, Guid idTelefone)
        {
            IdDadosCobranca = idDadosCobranca;
            IdTelefone = idTelefone;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idDadosCobranca, Guid idTelefone)
        {
            IdDadosCobranca = idDadosCobranca;
            IdTelefone = idTelefone;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
