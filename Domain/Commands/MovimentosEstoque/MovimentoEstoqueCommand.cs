using SharedKernel.MediatR;

namespace Domain.Commands.MovimentosEstoque
{
    public abstract class MovimentoEstoqueCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public MovimentoEstoqueCommand()
        {

        }

        public MovimentoEstoqueCommand(Guid id, string descricao)
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