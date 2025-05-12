namespace Domain.Commands.ObrasProjetos.Atualizar
{
    public class AtualizarObraProjetoCommand : ObraProjetoCommand<AtualizarObraProjetoCommand>
    {
        public AtualizarObraProjetoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }

        public AtualizarObraProjetoCommand()
        {

        }
    }
}