using SharedKernel.MediatR;

namespace Domain.Commands.Feriados
{
    public abstract class FeriadoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public FeriadoCommand()
        {

        }

        public FeriadoCommand(Guid id, string? nome, DateTime data)
        {
            Id = id;
            Nome = nome;
            Data = data;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
