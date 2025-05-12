using Domain.Entities.Pessoas;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Enderecos
{
    public class Endereco : EntityId
    {
        public Guid IdTipoEndereco { get; private set; }
        public string EnderecoDescricao { get; private set; }
        public string Numero { get; private set; }
        public string? Complemento { get; private set; }
        public Guid? IdCidade { get; private set; }
        public string Bairro { get; private set; }
        public Guid? IdUf { get; private set; }
        public string Cep { get; private set; }
        public TipoEndereco? TiposEndereco { get; private set; }
        public Cidade? Cidade { get; private set; }
        public Estado? Estado { get; private set; }
        public ICollection<RelacionaPessoaEndereco>? RelacionaPessoaEnderecos { get; private set; }
        public ICollection<RelacionaPessoaContatoEndereco>? RelacionaPessoaContatoEnderecos { get; private set; }        
        public ICollection<RelacionaDadosCobrancaEndereco>? RelacionaDadosCobrancaEnderecos { get; private set; }
        public virtual Empresa Empresa { get; private set; }

        public Endereco() { }

        public Endereco(Guid idTipoEndereco, string enderecoDescricao, string numero, string complemento, Guid idCidade, string bairro, Guid idUf, string cep)
        {
            SetId(Guid.NewGuid());
            IdTipoEndereco = idTipoEndereco;
            EnderecoDescricao = enderecoDescricao;
            Numero = numero;
            Complemento = complemento;
            IdCidade = idCidade;
            Bairro = bairro;
            IdUf = idUf;
            Cep = cep;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idTipoEndereco, string enderecoDescricao, string numero, string complemento, Guid idCidade, string bairro, Guid idUf, string cep)
        {
            IdTipoEndereco = idTipoEndereco;
            EnderecoDescricao = enderecoDescricao;
            Numero = numero;
            Complemento = complemento;
            IdCidade = idCidade;
            Bairro = bairro;
            IdUf = idUf;
            Cep = cep;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
