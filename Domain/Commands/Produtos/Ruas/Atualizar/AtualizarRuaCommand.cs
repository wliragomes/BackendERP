namespace Domain.Commands.Produtos.Ruas.Atualizar
{
    public class AtualizarRuaCommand : RuaCommand<AtualizarRuaCommand>
    {
        public AtualizarRuaCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarRuaCommand()
        {

        }
    }
}
