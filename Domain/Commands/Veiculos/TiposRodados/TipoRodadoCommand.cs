using SharedKernel.MediatR;

namespace Domain.Commands.TiposRodados
{
    public abstract class TipoRodadoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public TipoRodadoCommand()
        {

        }

        public TipoRodadoCommand(Guid id, string? descricao)
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