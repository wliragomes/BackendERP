using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.TiposPrecos
{
    public abstract class TipoPrecoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public TipoPrecoCommand()
        {

        }

        public TipoPrecoCommand(Guid id, string? descricao)
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
