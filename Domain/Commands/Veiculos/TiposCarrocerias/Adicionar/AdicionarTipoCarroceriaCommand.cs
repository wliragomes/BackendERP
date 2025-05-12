namespace Domain.Commands.TiposCarrocerias.Adicionar
{
    public class AdicionarTipoCarroceriaCommand : TipoCarroceriaCommand<AdicionarTipoCarroceriaCommand>
    {
        public AdicionarTipoCarroceriaCommand()
        {

        }

        public AdicionarTipoCarroceriaCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }
    }
}
