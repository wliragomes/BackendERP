using SharedKernel.MediatR;

namespace Domain.Commands.ObrasPadrao
{
    public abstract class ObraPadraoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ObraPadraoCommand()
        {

        }

        public ObraPadraoCommand(Guid id, string nome)
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