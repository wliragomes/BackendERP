namespace Domain.Commands.Produtos.TiposPrecos.Atualizar
{
    public class AtualizarTipoPrecoCommand : TipoPrecoCommand<AtualizarTipoPrecoCommand>
    {
        public AtualizarTipoPrecoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarTipoPrecoCommand()
        {

        }
    }
}
