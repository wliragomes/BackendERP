namespace Domain.Commands.ObraFases.Atualizar
{
    public class AtualizarObraFaseCommand : ObraFaseCommand<AtualizarObraFaseCommand>
    {
        public AtualizarObraFaseCommand(Guid id, string nome)
            : base(id, nome)
        {
        }

        public AtualizarObraFaseCommand()
        {

        }
    }
}