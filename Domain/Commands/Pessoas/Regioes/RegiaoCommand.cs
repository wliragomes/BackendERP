using SharedKernel.MediatR;

namespace Domain.Commands.Regioes
{
    public abstract class RegiaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public RegiaoCommand()
        {

        }

        public RegiaoCommand(Guid id, string? descricao)
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