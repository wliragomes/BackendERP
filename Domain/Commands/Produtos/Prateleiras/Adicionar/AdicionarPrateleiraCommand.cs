namespace Domain.Commands.Produtos.Prateleiras.Adicionar
{
    public class AdicionarPrateleiraCommand : PrateleiraCommand<AdicionarPrateleiraCommand>
    {
        public AdicionarPrateleiraCommand()
        {

        }

        public AdicionarPrateleiraCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
