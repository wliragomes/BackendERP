using SharedKernel.MediatR;

namespace Domain.Commands.Impostos.Piss
{
    public abstract class PisCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string PisAmigavel { get; set; }
        public string Nome { get; set; }
        public bool DescontaPis { get; set; }

        public PisCommand()
        {

        }

        public PisCommand(Guid id, string nome, string pisAmigavel, bool descontaPis)
        {
            Id = id;
            Nome = nome;
            PisAmigavel = pisAmigavel;
            DescontaPis = descontaPis;

        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
