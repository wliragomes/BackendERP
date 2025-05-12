namespace Domain.Commands.FusoHorarios.Adicionar
{
    public class AdicionarFusoHorarioCommand : FusoHorarioCommand<AdicionarFusoHorarioCommand>
    {
        public AdicionarFusoHorarioCommand()
        {

        }

        public AdicionarFusoHorarioCommand(Guid id, string numeroFusoHorario)
            : base(id, numeroFusoHorario)
        {
        }
    }
}
