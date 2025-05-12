using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.TiposProdutos
{
    public abstract class TipoProdutoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public TipoProdutoCommand()
        {

        }

        public TipoProdutoCommand(Guid id, string? descricao)
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
