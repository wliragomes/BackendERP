namespace Domain.Commands.Feriados.Adicionar
{
    public class AdicionarFeriadoCommand : FeriadoCommand<AdicionarFeriadoCommand>
    {
        public AdicionarFeriadoCommand()
        {

        }

        public AdicionarFeriadoCommand(Guid id, string? nome, DateTime data)
            : base(id, nome, data)
        {
        }
    }
}
