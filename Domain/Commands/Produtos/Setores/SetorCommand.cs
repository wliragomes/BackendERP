using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Setores
{
    public abstract class SetorCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public SetorCommand()
        {

        }

        public SetorCommand(Guid id, string? descricao)
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