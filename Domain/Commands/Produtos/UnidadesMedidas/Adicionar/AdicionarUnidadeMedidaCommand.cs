namespace Domain.Commands.Produtos.UnidadesMedidas.Adicionar
{
    public class AdicionarUnidadeMedidaCommand : UnidadeMedidaCommand<AdicionarUnidadeMedidaCommand>
    {
        public AdicionarUnidadeMedidaCommand()
        {

        }

        public AdicionarUnidadeMedidaCommand(Guid id, string descricao, string sigla, int ncasadecimal)
            : base(id, descricao, sigla, ncasadecimal)
        {
        }
    }
}
