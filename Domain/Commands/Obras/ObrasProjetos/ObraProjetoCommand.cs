using SharedKernel.MediatR;

namespace Domain.Commands.ObrasProjetos
{
    public abstract class ObraProjetoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ObraProjetoCommand()
        {

        }

        public ObraProjetoCommand(Guid id, string nome)
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