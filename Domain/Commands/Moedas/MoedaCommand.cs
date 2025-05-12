using SharedKernel.MediatR;

namespace Domain.Commands.Moedas
{
    public abstract class MoedaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Negociavel { get; set; }

        public MoedaCommand()
        {

        }

        public MoedaCommand(Guid id, string nome, bool negociavel)
        {
            Id = id;
            Nome = nome;
            Negociavel = negociavel;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}