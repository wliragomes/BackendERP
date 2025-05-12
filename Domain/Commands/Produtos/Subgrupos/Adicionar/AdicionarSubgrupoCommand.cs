namespace Domain.Commands.Produtos.Subgrupos.Adicionar
{
    public class AdicionarSubgrupoCommand : SubgrupoCommand<AdicionarSubgrupoCommand>
    {
        public AdicionarSubgrupoCommand()
        {

        }

        public AdicionarSubgrupoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
