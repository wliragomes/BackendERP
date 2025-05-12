namespace Domain.Commands.Feriados.Atualizar
{
    public class AtualizarFeriadoCommand : FeriadoCommand<AtualizarFeriadoCommand>
    {
        public AtualizarFeriadoCommand(Guid id, string nome, DateTime data)
            : base(id, nome, data)
        {
        }

        public AtualizarFeriadoCommand()
        {

        }
    }
}