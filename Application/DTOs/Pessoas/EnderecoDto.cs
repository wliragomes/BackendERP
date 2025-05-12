namespace Application.DTOs.Pessoas
{
    public class EnderecoDto
    {
        public Guid IdTipoEndereco { get; set; }
        public string EnderecoDescricao { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid? IdCidade { get; set; }
        public string Bairro { get; set; }
        public Guid? IdUf { get; set; }
        public string Cep { get; set; }
    }
}
