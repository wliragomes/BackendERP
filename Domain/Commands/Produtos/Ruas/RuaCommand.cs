using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Ruas
{
    public abstract class RuaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public RuaCommand()
        {

        }

        public RuaCommand(Guid id, string? descricao)
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