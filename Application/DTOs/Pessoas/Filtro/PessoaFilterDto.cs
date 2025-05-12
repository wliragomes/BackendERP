namespace Application.DTOs.Pessoas.Filtro
{
    public class PessoaFilterDto
    {
        public Guid Id { get; set; }
        public bool? Ativo { get; set; }
        public string UF { get; set; }
        public string? CnpjCpf { get; set; }
        public string RazaoSocial { get; set; }
        public bool? Vendedor { get; set; }
        public bool? Fornecedor { get; set; }
        public bool? Usuario { get; set; }
    }
}
