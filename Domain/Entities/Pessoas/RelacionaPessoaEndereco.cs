using Domain.Entities.Enderecos;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaPessoaEndereco : Entity
    {
        public Guid IdPessoa { get; private set; }
        public Pessoa? Pessoa { get; private set; }
        public Guid IdEndereco { get; private set; }
        public Endereco? Endereco { get; private set; }

        public RelacionaPessoaEndereco() { }

        public RelacionaPessoaEndereco(Guid idPessoa, Guid idEndereco)
        {
            IdPessoa = idPessoa;
            IdEndereco = idEndereco;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPessoa, Guid idEndereco) 
        {
            IdPessoa = idPessoa;
            IdEndereco = idEndereco;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
