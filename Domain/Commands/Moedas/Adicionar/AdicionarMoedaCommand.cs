namespace Domain.Commands.Moedas.Adicionar
{
    public class AdicionarMoedaCommand : MoedaCommand<AdicionarMoedaCommand>
    {
        public AdicionarMoedaCommand()
        {

        }

        public AdicionarMoedaCommand(Guid id, string nome, bool negociavel)
            : base(id, nome, negociavel)
        {
        }
    }
}
