namespace Domain.Commands.ObraFases.Adicionar
{
    public class AdicionarObraFaseCommand : ObraFaseCommand<AdicionarObraFaseCommand>
    {
        public AdicionarObraFaseCommand()
        {

        }

        public AdicionarObraFaseCommand(Guid id, string nome)
            : base(id, nome)
        {
        }
    }
}
