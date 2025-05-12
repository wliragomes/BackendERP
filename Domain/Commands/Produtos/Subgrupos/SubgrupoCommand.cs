using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Subgrupos
{
    public abstract class SubgrupoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public SubgrupoCommand()
        {

        }

        public SubgrupoCommand(Guid id, string? descricao)
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
