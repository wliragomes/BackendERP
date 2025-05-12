namespace Domain.Commands.ObraOrigems.Atualizar
{
    public class AtualizarObraOrigemCommand : ObraOrigemCommand<AtualizarObraOrigemCommand>
    {
        public AtualizarObraOrigemCommand(Guid id, string nome)
            : base(id, nome)
        {
        }

        public AtualizarObraOrigemCommand()
        {

        }
    }
}