namespace Domain.Commands.TiposCarrocerias.Atualizar
{
    public class AtualizarTipoCarroceriaCommand : TipoCarroceriaCommand<AtualizarTipoCarroceriaCommand>
    {
        public AtualizarTipoCarroceriaCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarTipoCarroceriaCommand()
        {

        }
    }
}