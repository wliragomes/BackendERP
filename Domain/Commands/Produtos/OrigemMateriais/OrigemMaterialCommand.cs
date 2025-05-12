using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.OrigemMateriais
{
    public abstract class OrigemMaterialCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public OrigemMaterialCommand()
        {

        }

        public OrigemMaterialCommand(Guid id, string? descricao)
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
