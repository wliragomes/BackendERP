using SharedKernel.MediatR;

namespace Domain.Commands.SegmentoClientes
{
    public abstract class SegmentoClienteCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public SegmentoClienteCommand()
        {

        }

        public SegmentoClienteCommand(Guid id, string? descricao)
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