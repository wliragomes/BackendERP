using SharedKernel.MediatR;

namespace Domain.Commands.Origens
{
    public abstract class OrigemCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public OrigemCommand()
        {

        }

        public OrigemCommand(Guid id, string? descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}