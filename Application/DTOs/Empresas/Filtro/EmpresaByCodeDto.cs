using Application.DTOs.Pessoas;

namespace Application.DTOs.Empresas
{
    public class EmpresaByCodeDto
    {
        public Guid Id { get; set; }
        public List<SocioDto>? Socios { get; set; }
        public string? CpfCnpj { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoSuframa { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
        public Guid? IdRegimeTributario { get; set; }
        public Guid? IdEndereco { get; set; }
        public EnderecoDto? Endereco { get; set; }
        public Guid? IdEmail { get; set; }
        public EmailDto? Email { get; set; }
        public Guid? IdTelefone { get; set; }
        public TelefoneDto? Telefone { get; set; }
        public List<ParametroFaturaDto>? ParametroFatura { get; set; }

    }
}

