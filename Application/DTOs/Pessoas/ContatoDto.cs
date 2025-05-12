namespace Application.DTOs.Pessoas
{
    public class ContatoDto
    {
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public Guid? IdDepartamento { get; set; }
        public Guid? IdCargo { get; set; }
        public string? Secretaria { get; set; }
        public DateTime? DataAniversario { get; set; }
        public EmailDto? Email { get; set; }
        public List<EnderecoDto>? Enderecos { get; set; }
        public List<TelefoneDto>? Telefones { get; set; }
    }
}
