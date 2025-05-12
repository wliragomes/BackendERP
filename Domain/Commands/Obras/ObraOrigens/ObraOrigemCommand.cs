using SharedKernel.MediatR;

namespace Domain.Commands.ObraOrigems
{
    public abstract class ObraOrigemCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ObraOrigemCommand()
        {

        }

        public ObraOrigemCommand(Guid id, string nome)
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