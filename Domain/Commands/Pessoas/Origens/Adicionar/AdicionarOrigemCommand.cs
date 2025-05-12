namespace Domain.Commands.Origens.Adicionar
{
    public class AdicionarOrigemCommand : OrigemCommand<AdicionarOrigemCommand>
    {
        public AdicionarOrigemCommand()
        {

        }

        public AdicionarOrigemCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}