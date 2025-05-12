using SharedKernel.MediatR;

namespace Domain.Commands.ObraFases
{
    public abstract class ObraFaseCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ObraFaseCommand()
        {

        }

        public ObraFaseCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}