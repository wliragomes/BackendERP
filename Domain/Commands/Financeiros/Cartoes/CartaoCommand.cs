using SharedKernel.MediatR;

namespace Domain.Commands.Cartoes
{
    public abstract class CartaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public CartaoCommand()
        {

        }

        public CartaoCommand(Guid id, string nome)
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