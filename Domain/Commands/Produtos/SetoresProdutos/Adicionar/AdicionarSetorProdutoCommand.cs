namespace Domain.Commands.Produtos.SetoresProdutos.Adicionar
{
    public class AdicionarSetorProdutoCommand : SetorProdutoCommand<AdicionarSetorProdutoCommand>
    {
        public AdicionarSetorProdutoCommand()
        {
        }

        public AdicionarSetorProdutoCommand(Guid id, string codigoSetor, bool componente, int cmax, int cmin, int lmax, int lmin, string descricao, bool perfil,
                                            int cobrancaMinima, bool setorFabricacao, bool pvb, bool argonio, bool mostrarCadastro)
            : base(id, codigoSetor, componente, cmax, cmin, lmax, lmin, descricao, perfil, cobrancaMinima, setorFabricacao, pvb, argonio, mostrarCadastro)
        {
        }
    }
}