using Domain.Entities.Vendas;
using Domain.Entities.VendasItem;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class Produto : EntityIdNome
    {
        public string? CodigoAmigavel { get; set; }
        public Guid? IdUnidadeMedida { get; set; }
        public decimal? Espessura { get; set; }
        public decimal? PesoBruto { get; set; }
        public decimal? PesoLiquido { get; set; }
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
        public UnidadeMedida? UnidadeMedida { get; set; }
        public CodigoImportacao? CodigoImportacao { get; set; }
        public SetorProduto? SetorProduto { get; set; }
        public TipoProduto? TipoProduto { get; set; }
        public Grupo? Grupo { get; set; }
        public Subgrupo? Subgrupo { get; set; }
        public Familia? Familia { get; set; }
        public Setor? Setor { get; set; }
        public Rua? Rua { get; set; }
        public Prateleira? Prateleira { get; set; }
        public ICollection<PrecosTributacoes>? PrecosTributacoes { get; set; }
        public ICollection<Composicao>? Composicao { get; set; }
        public ICollection<RelacionaProdutoFornecedor>? RelacionaProdutoFornecedor { get; set; }  
        public virtual OrdemFabricacaoItem OrdemFabricacaoItem { get; set; }  
        public virtual List<VendaItem> VendaItem { get; set; }  
        //public virtual PlanejamentoProducao PlanejamentoProducao { get; set; }  

        public Produto() { }

        public Produto(string? codigoAmigavel, string? nome, Guid idUnidadeMedida, decimal espessura, decimal pesoBruto, decimal pesoLiquido, Guid idSetorProduto,
                           string? codigoBarras, decimal estoqueMinimo, decimal estoqueMaximo, Guid? idMateriaPrima, Guid idCodigoImportacao,
                           string corteCerto, Guid idTipoProduto, Guid idGrupo, Guid idSubgrupo, Guid idFamilia, Guid idSetor, Guid idRua, Guid idPrateleira, string? posicao,
                           string? informacoesComplementares, bool? edgeDeleton, bool? bloqueado, DateTime? dataBloqueio)
        {
            SetId(Guid.NewGuid());
            CodigoAmigavel = codigoAmigavel;
            SetNome(nome);
            IdUnidadeMedida = idUnidadeMedida;
            Espessura = espessura;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            IdSetorProduto = idSetorProduto;
            CodigoBarras = codigoBarras;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
            IdMateriaPrima = idMateriaPrima;
            IdCodigoImportacao = idCodigoImportacao;
            CorteCerto = corteCerto;
            IdTipoProduto = idTipoProduto;
            IdGrupo = idGrupo;
            IdSubgrupo = idSubgrupo;
            IdFamilia = idFamilia;
            IdSetor = idSetor;
            IdRua = idRua;
            IdPrateleira = idPrateleira;
            Posicao = posicao;
            InformacoesComplementares = informacoesComplementares;
            EdgeDeleton = edgeDeleton;
            Bloqueado = bloqueado;
            DataBloqueio = dataBloqueio;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string? codigoAmigavel, string? nome, Guid idUnidadeMedida, decimal espessura, decimal pesoBruto, decimal pesoLiquido, Guid idSetorProduto, 
                           string? codigoBarras, decimal estoqueMinimo, decimal estoqueMaximo, Guid? idMateriaPrima, Guid idCodigoImportacao,
                           string corteCerto, Guid idTipoProduto, Guid idGrupo, Guid idSubgrupo, Guid idFamilia, Guid idSetor, Guid idRua, Guid idPrateleira, string? posicao, 
                           string? informacoesComplementares, bool? edgeDeleton, bool? bloqueado, DateTime? dataBloqueio)
        {
            
            CodigoAmigavel = codigoAmigavel;
            SetNome(nome);
            IdUnidadeMedida = idUnidadeMedida;
            Espessura = espessura;
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            IdSetorProduto = idSetorProduto;
            CodigoBarras = codigoBarras;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
            IdMateriaPrima = idMateriaPrima;
            IdCodigoImportacao = idCodigoImportacao;
            CorteCerto = corteCerto;
            IdTipoProduto = idTipoProduto;
            IdGrupo = idGrupo;
            IdSubgrupo = idSubgrupo;
            IdFamilia = idFamilia;
            IdSetor = idSetor;
            IdRua = idRua;
            IdPrateleira = idPrateleira;
            Posicao = posicao;
            InformacoesComplementares = informacoesComplementares;
            EdgeDeleton = edgeDeleton;
            Bloqueado = bloqueado;
            DataBloqueio = dataBloqueio;
        }
    }
}
