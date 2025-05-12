using Domain.Commands.Pessoas;
using SharedKernel.MediatR;

namespace Domain.Commands.Empresas
{
    public class EmpresaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public List<SocioCommand>? Socios { get; set; }
        public string? CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoSuframa { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public Guid? IdRegimeTributario { get; set; }
        public EnderecoCommand? Endereco { get; set; }
        public Guid? IdEndereco { get; set; }
        public EmailCommand? Email { get; set; }
        public Guid? IdEmail { get; set; }
        public TelefoneCommand? Telefone { get; set; }
        public Guid? IdTelefone { get; set; }
        public List<ParametroFaturaCommand>? ParametroFatura { get; set; }

        public EmpresaCommand()
        {

        }

        public EmpresaCommand(Guid id, string? cpfCnpj, string? inscricaoEstadual, string? inscricaoSuframa, string? razaoSocial, string? nomeFantasia, 
                              Guid? idRegimeTributario, Guid? idEndereco, Guid? idEmail, Guid? idTelefone)
        {
            Id = id;
            CpfCnpj = cpfCnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoSuframa = inscricaoSuframa;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            IdRegimeTributario = idRegimeTributario;
            IdEndereco = idEndereco;
            IdEmail = idEmail;
            IdTelefone = idTelefone;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}