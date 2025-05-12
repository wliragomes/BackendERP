namespace Application.DTOs.Pessoas.Filtro
{
    public class DadosCobrancaFilterDto
    {
        public string? Responsavel { get; set; }
        public List<EnderecoFilterDto>? Enderecos { get; set; }
        public List<TelefoneFilterDto>? Telefones { get; set; }
    }
}
