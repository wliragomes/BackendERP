namespace Application.DTOs.Pessoas.Filtro
{
    public class ContatoFilterDto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public PadraoIdDescricaoFilterDto? Departamento { get; set; }
        public PadraoIdDescricaoFilterDto? Cargo { get; set; }
        public string? Secretaria { get; set; }
        public DateTime? DataAniversario { get; set; }
        public PadraoIdDescricaoFilterDto? Email { get; set; }
        public List<EnderecoFilterDto>? Enderecos { get; set; }
        public List<TelefoneFilterDto>? Telefones { get; set; }
    }
}
