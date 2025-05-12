namespace Domain.Commands.ObraOrigems.Adicionar
{
    public class AdicionarObraOrigemCommand : ObraOrigemCommand<AdicionarObraOrigemCommand>
    {
        public AdicionarObraOrigemCommand()
        {

        }

        public AdicionarObraOrigemCommand(Guid id, string nome)
            : base(id, nome)
        {
        }
    }
}
