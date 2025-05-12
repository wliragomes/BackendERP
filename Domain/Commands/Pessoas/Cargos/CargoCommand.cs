using SharedKernel.MediatR;

namespace Domain.Commands.Cargos
{
    public abstract class CargoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public CargoCommand()
        {

        }

        public CargoCommand(Guid id, string? descricao)
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