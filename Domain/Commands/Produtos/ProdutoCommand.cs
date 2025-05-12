using SharedKernel.MediatR;

namespace Domain.Commands.Produtos
{
    public abstract class ProdutoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; protected set; }
        public string? CodigoAmigavel { get; protected set; }
        public string? Nome { get; protected set; }
        public Guid IdUnidadeMedida { get; protected set; }
        public decimal Espessura { get; protected set; }
        public decimal PesoBruto { get; protected set; }
        public decimal PesoLiquido { get; protected set; }
        public string CodigoLetra { get; protected set; }
        public Guid IdSetorProduto { get; protected set; }
        public string? CodigoBarras { get; protected set; }
        public decimal EstoqueMinimo { get; protected set; }
        public decimal EstoqueMaximo { get; protected set; }
        public Guid? IdMateriaPrima { get; protected set; }
        public Guid IdCodigoImportacao { get; protected set; }
        public string CorteCerto { get; protected set; }
        public Guid IdTipoProduto { get; protected set; }
        public Guid IdGrupo { get; protected set; }
        public Guid IdSubgrupo { get; protected set; }
        public Guid IdFamilia { get; protected set; }
        public Guid IdSetor { get; protected set; }
        public Guid IdRua { get; protected set; }
        public Guid IdPrateleira { get; protected set; }
        public string? Posicao { get; protected set; }
        public string? InformacoesComplementares { get; protected set; }
        public bool? EdgeDeleton { get; protected set; }
        public bool? Bloqueado { get; protected set; }
        public DateTime? DataBloqueio { get; protected set; }
        public List<PrecosTributacoesCommand>? PrecosTributacoes { get; set; }
        public List<ComposicaoCommand>? Composicao { get;  set; }
        public List<RelacionaProdutoFornecedorCommand>? Fornecedor { get;  set; }         

        protected ProdutoCommand()
        {

        }

        protected ProdutoCommand(Guid id, string? codigoAmigavel, string? nome, Guid idUnidadeMedida, decimal espessura, decimal pesoBruto, decimal pesoLiquido, string? codigoLetra,
                                 Guid idSetorProduto, string? codigoBarras, decimal estoqueMinimo, decimal estoqueMaximo, Guid? idMateriaPrima,
                                 Guid idCodigoImportacao, string? corteCerto, Guid idTipoProduto, Guid idGrupo, Guid idSubgrupo, Guid idFamilia, Guid idSetor, Guid idRua, Guid idPrateleira, 
                                 string? posicao, string? informacoesComplementares, bool edgeDeleton, bool bloqueado, DateTime? dataBloqueio)
        {
            Id=id;
            CodigoAmigavel=codigoAmigavel;
            Nome=nome;
            IdUnidadeMedida=idUnidadeMedida;
            Espessura=espessura;
            PesoBruto=pesoBruto;
            PesoLiquido=pesoLiquido;
            CodigoLetra = codigoLetra;
            IdSetorProduto=idSetorProduto;
            CodigoBarras=codigoBarras;
            EstoqueMinimo=estoqueMinimo;
            EstoqueMaximo=estoqueMaximo;
            IdMateriaPrima = idMateriaPrima;
            IdCodigoImportacao =idCodigoImportacao;
            CorteCerto = corteCerto;
            IdTipoProduto =idTipoProduto;
            IdGrupo=idGrupo;
            IdSubgrupo=idSubgrupo;
            IdFamilia=idFamilia;
            IdSetor=idSetor;
            IdRua=idRua;
            IdPrateleira=idPrateleira;
            Posicao=posicao;
            InformacoesComplementares=informacoesComplementares;
            EdgeDeleton=edgeDeleton;
            Bloqueado=bloqueado;
            DataBloqueio=dataBloqueio;            
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
