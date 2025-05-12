using Domain.Entities;

namespace Application.DTOs.Vendas
{
    public class EnderecoVendaDto
    {
        public Guid IdTipoEndereco { get; set; }
        public string EnderecoDescricao { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Cidade { get; set; }  // Alterado para string
        public string Bairro { get; set; }
        public string? Estado { get; set; }  // Alterado para string
        public string Cep { get; set; }
    }
}
