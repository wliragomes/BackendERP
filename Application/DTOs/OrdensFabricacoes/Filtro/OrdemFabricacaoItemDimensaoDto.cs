namespace Application.DTOs.OrdensFabricacoes.Filtro
{
    public class OrdemFabricacaoItemDimensaoDto
    {
        public int altura_mm { get; set; }
        public int largura_mm { get; set; }
        public int quantidade_pecas { get; set; }
        public string? cod_vidro { get; set; }
        public decimal arredondamento { get; set; }
        public decimal vlr_modulado { get; set; }
        public string ds_projeto { get; set; }
    }
}
