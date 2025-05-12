namespace Domain.Commands.Pessoas
{
    public class ContatoCommand
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public Guid IdDepartamento { get; set; }
        public Guid IdCargo { get; set; }
        public string Secretaria { get; set; }
        public DateTime? DataAniversario { get; set; }
        public EmailCommand Email { get; set; }
        public List<EnderecoCommand>? Enderecos { get; set; }
        public List<TelefoneCommand>? Telefones { get; set; }
    }
}
