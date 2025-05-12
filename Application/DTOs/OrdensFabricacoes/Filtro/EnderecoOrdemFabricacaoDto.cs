namespace Application.DTOs.OrdensFabricacoes.Filtro
{
    public class EnderecoOrdemFabricacaoDto
    {
        public Guid Id { get; set; }
        public Guid IdEnderecoEntrega { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid? IdEstado { get; set; }
        public Guid? IdCidade { get; set; }
        public string? Bairro { get; set; }
    }
}