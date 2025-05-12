using Domain.Entities.Empresas;
using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Telefones
{
    public class Telefone : EntityId
    {
        public Guid IdTipoTelefone { get; private set; }
        public string Numero { get; private set; }
        public TipoTelefone? TiposTelefone { get; private set; }
        public ICollection<RelacionaPessoaTelefone>? RelacionaPessoaTelefones { get; private set; }
        public ICollection<RelacionaPessoaContatoTelefone>? RelacionaPessoaContatoTelefones { get; private set; }
        public ICollection<RelacionaDadosCobrancaTelefone>? RelacionaDadosCobrancaTelefones { get; private set; }
        public virtual Empresa Empresa { get; private set; }

        public Telefone() { }

        public Telefone(Guid tiposTelefone, string numero)
        {
            SetId(Guid.NewGuid());
            IdTipoTelefone = tiposTelefone;
            Numero = numero;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid tiposTelefone, string numero)
        {
            IdTipoTelefone = tiposTelefone;
            Numero = numero;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
