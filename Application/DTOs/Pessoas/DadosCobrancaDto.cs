namespace Application.DTOs.Pessoas
{
    public class DadosCobrancaDto
    {
        public string? Responsavel { get; set; }
        public List<EnderecoDto>? Enderecos { get; set; }
        public List<TelefoneDto>? Telefones { get; set; }
    }
}
