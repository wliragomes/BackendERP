using Domain.Entities.Emails;
using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Contatos
{
    public class Contato : EntityIdNome
    {
        public Guid IdPessoa { get; private set; }
        public string? Apelido { get; private set; }
        public Guid? IdDepartamento { get; private set; }
        public Guid? IdCargo { get; private set; }
        public string? Secretaria { get; private set; }
        public DateTime? DataAniversario { get; private set; }
        public Guid? IdEmail { get; private set; }
        public ICollection<RelacionaPessoaContatoEndereco>? RelacionaPessoaContatoEnderecos { get; private set; }
        public ICollection<RelacionaPessoaContatoTelefone>? RelacionaPessoaContatoTelefones { get; private set; }
        public Departamento? Departamento { get; private set; }
        public Cargo? Cargo { get; private set; }
        public Pessoa Pessoa { get; private set; }
        public Email? Email { get; private set; }

        public Contato() {}

        public Contato(Guid idPessoa, string nome, string apelido, Guid idDepartamento, Guid idCargo, string secretaria, DateTime? dataAniversario, Guid iDemail)
        {
            SetId(Guid.NewGuid());
            IdPessoa = idPessoa;
            SetNome(nome);
            Apelido = apelido;
            IdDepartamento = idDepartamento;
            IdCargo = idCargo;
            Secretaria = secretaria;
            DataAniversario = dataAniversario;
            IdEmail = iDemail;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idPessoa, string nome, string apelido, Guid idDepartamento, Guid idCargo, string secretaria, DateTime? dataAniversario, Guid iDemail)
        {
            IdPessoa = idPessoa;
            SetNome(nome);
            Apelido = apelido;
            IdDepartamento = idDepartamento;
            IdCargo = idCargo;
            Secretaria = secretaria;
            DataAniversario = dataAniversario;
            IdEmail = iDemail;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
