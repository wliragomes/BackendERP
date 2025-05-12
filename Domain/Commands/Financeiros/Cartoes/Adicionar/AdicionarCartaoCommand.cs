namespace Domain.Commands.Cartoes.Adicionar
{
    public class AdicionarCartaoCommand : CartaoCommand<AdicionarCartaoCommand>
    {
        public AdicionarCartaoCommand()
        {

        }

        public AdicionarCartaoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }
    }
}
