namespace Domain.Commands.Produtos.UnidadesMedidas.Atualizar
{
    public class AtualizarUnidadeMedidaCommand : UnidadeMedidaCommand<AtualizarUnidadeMedidaCommand>
    {
        public AtualizarUnidadeMedidaCommand(Guid id, string descricao, string sigla, int ncasadecimal)
            : base(id, descricao, sigla, ncasadecimal)
        {
        }

        public AtualizarUnidadeMedidaCommand()
        {

        }
    }
}
