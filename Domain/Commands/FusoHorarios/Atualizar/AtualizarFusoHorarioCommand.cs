namespace Domain.Commands.FusoHorarios.Atualizar
{
    public class AtualizarFusoHorarioCommand : FusoHorarioCommand<AtualizarFusoHorarioCommand>
    {
        public AtualizarFusoHorarioCommand(Guid id, string numeroFusoHorario)
            : base(id, numeroFusoHorario)
        {
        }

        public AtualizarFusoHorarioCommand()
        {

        }
    }
}