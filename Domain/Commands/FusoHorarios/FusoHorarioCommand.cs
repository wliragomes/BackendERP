using SharedKernel.MediatR;

namespace Domain.Commands.FusoHorarios
{
    public abstract class FusoHorarioCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string NumeroFusoHorario { get; set; }

        public FusoHorarioCommand()
        {

        }

        public FusoHorarioCommand(Guid id, string numeroFusoHorario)
        {
            Id = id;
            NumeroFusoHorario = numeroFusoHorario;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}