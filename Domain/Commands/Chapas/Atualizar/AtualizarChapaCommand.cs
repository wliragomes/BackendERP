namespace Domain.Commands.Chapas.Atualizar
{
    public class AtualizarChapaCommand : ChapaCommand<AtualizarChapaCommand>
    {
        public AtualizarChapaCommand(Guid id, string descricao, int altura, int largura)
            : base(id, descricao, altura, largura)
        {
        }

        public AtualizarChapaCommand()
        {

        }
    }
}