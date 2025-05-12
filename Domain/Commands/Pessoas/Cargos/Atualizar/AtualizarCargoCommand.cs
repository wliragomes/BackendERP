namespace Domain.Commands.Cargos.Atualizar
{
    public class AtualizarCargoCommand : CargoCommand<AtualizarCargoCommand>
    {
        public AtualizarCargoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarCargoCommand()
        {

        }
    }
}