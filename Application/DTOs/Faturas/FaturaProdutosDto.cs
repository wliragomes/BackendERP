namespace Application.DTOs.Faturas
{
    public class FaturaProdutosDto
    {
        public int SequenciaItem { get; set; }
        public Guid IdProduto { get; set; }
        public string? CodigoAmigavel { get; set; }
        public string? DescricaoProduto { get; set; }
        public bool? Jumbo { get; set; }
        public string? InformacoesAdicionais { get; set; }
        public string? DescricaoPedidoCliente { get; set; }
        public string? NumeroItemPedidoCliente { get; set; }
        public string? NumeroFCI { get; set; }
        public decimal? ValorFCI { get; set; }
        public Guid IdUnidadeMedida { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid? idNCM { get; set; }
        public Guid? IdCFOP { get; set; }
        public decimal AliquotaICMS { get; set; }
        public decimal BaseCalculoICMS { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal AliquotaIPI { get; set; }
        public decimal ValorIPI { get; set; }
        public decimal BaseCalculoST { get; set; }
        public decimal AliquotaST { get; set; }
        public decimal ValorST { get; set; }
    }
}
