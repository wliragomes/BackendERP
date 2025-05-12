namespace Domain.Commands.Impostos.Piss.Adicionar
{
    public class AdicionarPisCommand : PisCommand<AdicionarPisCommand>
    {
        public AdicionarPisCommand()
        {

        }

        public AdicionarPisCommand(Guid id, string nome, string pisAmigavel, bool descontaPis)
            : base(id, nome, pisAmigavel, descontaPis)
        {
        }
    }
}
