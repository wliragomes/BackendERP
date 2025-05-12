namespace Domain.Commands.Regioes.Atualizar
{
    public class AtualizarRegiaoCommand : RegiaoCommand<AtualizarRegiaoCommand>
    {
        public AtualizarRegiaoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarRegiaoCommand()
        {

        }
    }
}