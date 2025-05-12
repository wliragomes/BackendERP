namespace Domain.Commands.Pessoas
{
    public class DadosCobrancaCommand
    {
        public string? Responsavel { get; set; }
        public List<EnderecoCommand>? Enderecos { get; set; }
        public List<TelefoneCommand>? Telefones { get; set; }
    }
}
