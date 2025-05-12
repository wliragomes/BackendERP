using SharedKernel.MediatR;

namespace Domain.Commands.Produtos.Grupos
{
    public abstract class GrupoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public GrupoCommand()
        {

        }

        public GrupoCommand(Guid id, string? descricao)
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
