using SharedKernel.MediatR;

namespace Domain.Commands.TiposCarrocerias
{
    public abstract class TipoCarroceriaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public TipoCarroceriaCommand()
        {

        }

        public TipoCarroceriaCommand(Guid id, string? descricao)
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