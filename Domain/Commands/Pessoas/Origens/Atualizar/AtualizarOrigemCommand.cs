namespace Domain.Commands.Origens.Atualizar
{
    public class AtualizarOrigemCommand : OrigemCommand<AtualizarOrigemCommand>
    {
        public AtualizarOrigemCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarOrigemCommand()
        {

        }
    }
}