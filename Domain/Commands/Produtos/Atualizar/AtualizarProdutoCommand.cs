namespace Domain.Commands.Produtos.Atualizar
{
    public class AtualizarProdutoCommand : ProdutoCommand<AtualizarProdutoCommand>
    {
        public AtualizarProdutoCommand(Guid id, string? CodigoAmigavel, string? nome, Guid idUnidadeMedida, decimal Espessura, decimal PesoBruto, decimal PesoLiquido,
                                       string? codigoLetra, Guid IdSetorProduto, string? CodigoBarras, decimal EstoqueMinimo, decimal EstoqueMaximo, Guid? IdMateriaPrima,
                                       Guid IdCodigoImportacao, string? corteCerto, Guid IdTipoProduto, Guid IdGrupo, Guid IdSubgrupo, Guid IdFamilia, Guid IdSetor, Guid IdRua,
                                       Guid IdPrateleira, string? Posicao, string? InformacoesComplementares, bool EdgeDeleton, bool Bloqueado, DateTime? DataBloqueio)

            : base(id, CodigoAmigavel, nome, idUnidadeMedida, Espessura, PesoBruto, PesoLiquido, codigoLetra, IdSetorProduto, CodigoBarras,
                   EstoqueMinimo, EstoqueMaximo, IdMateriaPrima, IdCodigoImportacao, corteCerto, IdTipoProduto, IdGrupo, IdSubgrupo, IdFamilia, IdSetor, IdRua, IdPrateleira, Posicao,
                   InformacoesComplementares, EdgeDeleton, Bloqueado, DataBloqueio)
        {
        }

        public AtualizarProdutoCommand()
        {

        }
    }
}
