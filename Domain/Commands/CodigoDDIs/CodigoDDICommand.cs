using SharedKernel.MediatR;

namespace Domain.Commands.CodigoDDIs
{
    public abstract class CodigoDDICommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }

        public CodigoDDICommand()
        {

        }

        public CodigoDDICommand(Guid id, string codigo)
        {
            Id = id;
            Codigo = codigo;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}