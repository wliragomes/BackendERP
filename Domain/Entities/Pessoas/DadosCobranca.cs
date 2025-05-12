using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class DadosCobranca : EntityId
    {
        public Guid IdPessoa { get; private set; }
        public string Responsavel { get; private set; }
        public Pessoa? Pessoa { get; private set; }
        public ICollection<RelacionaDadosCobrancaTelefone>? RelacionaDadosCobrancaTelefones { get; private set; }
        public ICollection<RelacionaDadosCobrancaEndereco>? RelacionaDadosCobrancaEnderecos { get; private set; }

        public DadosCobranca(Guid idPessoa, string responsavel)
        {
            SetId(Guid.NewGuid());
            IdPessoa = idPessoa;
            Responsavel = responsavel;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPessoa, string responsavel)
        {
            IdPessoa = idPessoa;
            Responsavel = responsavel;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
