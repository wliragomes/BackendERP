namespace Domain.Commands.Produtos.Subgrupos.Atualizar
{
    public class AtualizarSubgrupoCommand : SubgrupoCommand<AtualizarSubgrupoCommand>
    {
        public AtualizarSubgrupoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarSubgrupoCommand()
        {

        }
    }
}
