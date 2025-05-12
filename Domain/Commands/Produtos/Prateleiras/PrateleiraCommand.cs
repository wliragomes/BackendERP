using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Prateleiras
{
    public abstract class PrateleiraCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public PrateleiraCommand()
        {

        }

        public PrateleiraCommand(Guid id, string? descricao)
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
