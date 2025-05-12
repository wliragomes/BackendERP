using Domain.Entities.Contatos;
using Domain.Entities.Enderecos;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Pessoas
{
    public class RelacionaPessoaContatoEndereco : Entity
    {
        public Guid IdContato { get; private set; }
        public Contato? Contato { get; private set; }
        public Guid IdEndereco { get; private set; }
        public Endereco? Endereco { get; private set; }

        public RelacionaPessoaContatoEndereco() { }

        public RelacionaPessoaContatoEndereco(Guid idContato, Guid idEndereco)
        {
            IdContato = idContato;
            IdEndereco = idEndereco;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idContato, Guid idEndereco)
        {
            IdContato = idContato;
            IdEndereco = idEndereco;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
