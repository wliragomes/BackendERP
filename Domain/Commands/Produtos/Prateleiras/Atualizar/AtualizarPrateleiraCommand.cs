namespace Domain.Commands.Produtos.Prateleiras.Atualizar
{
    public class AtualizarPrateleiraCommand : PrateleiraCommand<AtualizarPrateleiraCommand>
    {
        public AtualizarPrateleiraCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarPrateleiraCommand()
        {

        }
    }
}
