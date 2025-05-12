namespace Domain.Commands.ObrasProjetos.Adicionar
{
    public class AdicionarObraProjetoCommand : ObraProjetoCommand<AdicionarObraProjetoCommand>
    {
        public AdicionarObraProjetoCommand()
        {

        }

        public AdicionarObraProjetoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }
    }
}
