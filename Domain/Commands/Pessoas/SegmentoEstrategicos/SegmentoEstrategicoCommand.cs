using SharedKernel.MediatR;

namespace Domain.Commands.SegmentoEstrategicos
{
    public abstract class SegmentoEstrategicoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public SegmentoEstrategicoCommand()
        {

        }

        public SegmentoEstrategicoCommand(Guid id, string? descricao)
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