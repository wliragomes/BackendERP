namespace Application.DTOs.Produtos.Adicionar
{
    public class AdicionarProdutoDto
    {
        public string? CodigoAmigavel { get; set; }
        public string? Nome { get; set; }
        public Guid? IdUnidadeMedida { get; set; }
        public decimal? Espessura { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
        public string? CodigoLetra { get; set; }        
        public Guid? IdSetorProduto { get; set; }
        public string? CodigoBarras { get; set; }
        public decimal? EstoqueMinimo { get; set; }
        public decimal? EstoqueMaximo { get; set; }
        public Guid? IdMateriaPrima { get; set; }
        public Guid? IdCodigoImportacao { get; set; }
        public string? CorteCerto { get; set; }
        public Guid? IdTipoProduto { get; set; }
        public Guid? IdGrupo { get; set; }
        public Guid? IdSubgrupo { get; set; }
        public Guid? IdFamilia { get; set; }
        public Guid? IdSetor { get; set; }
        public Guid? IdRua { get; set; }
        public Guid? IdPrateleira { get; set; }
        public string? Posicao { get; set; }
        public string? InformacoesComplementares { get; set; }
        public bool? EdgeDeleton { get; set; }
        public bool? Bloqueado { get; set; }
        public DateTime? DataBloqueio { get; set; }
        public List<PrecosTributacoesDto>? PrecosTributacoes { get; set; }
        public List<ComposicaoDto>? Composicao { get; set; }
        public List<RelacionaProdutoFornecedorDto>? Fornecedor { get; set; }        
    }
}
