namespace Domain.Commands.Cartoes.Atualizar
{
    public class AtualizarCartaoCommand : CartaoCommand<AtualizarCartaoCommand>
    {
        public AtualizarCartaoCommand(Guid id, string nome)
            : base(id, nome)
        {
        }

        public AtualizarCartaoCommand()
        {

        }
    }
}