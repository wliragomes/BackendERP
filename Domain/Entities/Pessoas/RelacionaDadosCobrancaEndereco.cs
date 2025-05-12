using Domain.Entities.Enderecos;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaDadosCobrancaEndereco : Entity
    {
        public Guid IdDadosCobranca { get; private set; }
        public DadosCobranca? DadosCobranca { get; private set; }
        public Guid IdEndereco { get; private set; }
        public Endereco? Endereco { get; private set; }

        public RelacionaDadosCobrancaEndereco() { }

        public RelacionaDadosCobrancaEndereco(Guid idDadosCobranca, Guid idEndereco)
        {
            IdDadosCobranca = idDadosCobranca;
            IdEndereco = idEndereco;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idDadosCobranca, Guid idEndereco)
        {
            IdDadosCobranca = idDadosCobranca;
            IdEndereco = idEndereco;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
