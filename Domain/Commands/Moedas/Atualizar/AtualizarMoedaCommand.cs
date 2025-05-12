namespace Domain.Commands.Moedas.Atualizar
{
    public class AtualizarMoedaCommand : MoedaCommand<AtualizarMoedaCommand>
    {
        public AtualizarMoedaCommand(Guid id, string nome, bool negociavel)
            : base(id, nome, negociavel)
        {
        }

        public AtualizarMoedaCommand()
        {

        }
    }
}