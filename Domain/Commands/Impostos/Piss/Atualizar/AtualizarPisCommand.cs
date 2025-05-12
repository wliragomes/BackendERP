namespace Domain.Commands.Impostos.Piss.Atualizar
{
    public class AtualizarPisCommand : PisCommand<AtualizarPisCommand>
    {
        public AtualizarPisCommand(Guid id, string nome, string pisAmigavel, bool descontaPis)
            : base(id, nome, pisAmigavel, descontaPis)
        {
        }

        public AtualizarPisCommand()
        {

        }
    }
}