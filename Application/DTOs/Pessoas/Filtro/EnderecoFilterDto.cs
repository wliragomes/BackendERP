namespace Application.DTOs.Pessoas.Filtro
{
    public class EnderecoFilterDto
    {
        public Guid? Id { get; set; }
        public string TipoEndereco { get; set; }
        public string EnderecoDescricao { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public PadraoIdDescricaoFilterDto? Cidade { get; set; }
        public string Bairro { get; set; }
        public PadraoIdDescricaoFilterDto? Uf { get; set; }
        public string Cep { get; set; }
    }
}
