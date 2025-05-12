namespace Domain.Commands.Produtos.Ruas.Adicionar
{
    public class AdicionarRuaCommand : RuaCommand<AdicionarRuaCommand>
    {
        public AdicionarRuaCommand()
        {

        }

        public AdicionarRuaCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}