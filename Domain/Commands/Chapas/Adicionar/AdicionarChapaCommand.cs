namespace Domain.Commands.Chapas.Adicionar
{
    public class AdicionarChapaCommand : ChapaCommand<AdicionarChapaCommand>
    {
        public AdicionarChapaCommand()
        {

        }

        public AdicionarChapaCommand(Guid id, string descricao, int altura, int largura)
            : base(id, descricao, altura, largura)
        {
        }
    }
}
