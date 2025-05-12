using SharedKernel.MediatR;

namespace Domain.Commands.Acabamentos
{
    public abstract class AcabamentoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Tolerancia { get; set; }

        public AcabamentoCommand()
        {

        }

        public AcabamentoCommand(Guid id, string descricao, bool tolerancia)
        {
            Id = id;
            Descricao = descricao;
            Tolerancia = tolerancia;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}