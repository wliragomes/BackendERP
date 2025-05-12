namespace Application.DTOs.Produtos.UnidadesMedidas.Filtro
{
    public class UnidadeMedidaFilterDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int CasaDecimal { get; set; }
    }
}
