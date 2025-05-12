namespace Domain.Commands.Cargos.Adicionar
{
    public class AdicionarCargoCommand : CargoCommand<AdicionarCargoCommand>
    {
        public AdicionarCargoCommand()
        {

        }

        public AdicionarCargoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}