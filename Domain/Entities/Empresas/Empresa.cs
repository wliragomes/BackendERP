using Domain.Entities.Emails;
using Domain.Entities.Empresas;
using Domain.Entities.Enderecos;
using Domain.Entities.Telefones;
using Domain.Entities.Vendas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Empresa : EntityId
    {
        public string? CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoSuframa { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public Guid? IdRegimeTributario { get; set; }
        public Guid? IdEndereco { get; set; }
        public Guid? IdEmail { get; set; }
        public Guid? IdTelefone { get; set; }
        public virtual Venda Venda { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        public virtual Email Email { get; private set; }
        public virtual Telefone Telefone { get; private set; }
        public List<RelacionaEmpresaSocio>? RelacionaEmpresaSocio { get; private set; }
        public List<RelacionaEmpresaFaturaParametro>? RelacionaEmpresaFaturaParametro { get; private set; }


        public Empresa(string? cpfCnpj, string? inscricaoEstadual, string? inscricaoSuframa, string? razaoSocial, string? nomeFantasia,
                       Guid? idRegimeTributario, Guid? idEndereco, Guid? idEmail, Guid? idTelefone)
        {
            SetId(Guid.NewGuid());
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoSuframa = inscricaoSuframa;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            IdRegimeTributario = idRegimeTributario;
            IdEndereco = idEndereco;
            IdEmail = idEmail;
            IdTelefone = idTelefone;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string? cpfCnpj, string? inscricaoEstadual, string? inscricaoSuframa, string? razaoSocial, string? nomeFantasia,
                           Guid? idRegimeTributario, Guid? idEndereco, Guid? idEmail, Guid? idTelefone)
        {
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoSuframa = inscricaoSuframa;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            IdRegimeTributario = idRegimeTributario;
            IdEndereco = idEndereco;
            IdEmail = idEmail;
            IdTelefone = idTelefone;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
