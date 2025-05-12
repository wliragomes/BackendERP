namespace Domain.Commands.Produtos.TiposPrecos.Adicionar
{
    public class AdicionarTipoPrecoCommand : TipoPrecoCommand<AdicionarTipoPrecoCommand>
    {
        public AdicionarTipoPrecoCommand()
        {

        }

        public AdicionarTipoPrecoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
