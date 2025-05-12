using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Familias
{
    public abstract class FamiliaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public FamiliaCommand()
        {

        }

        public FamiliaCommand(Guid id, string? descricao)
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
