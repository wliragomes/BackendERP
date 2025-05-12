using SharedKernel.MediatR;

namespace Domain.Commands.Departamentos
{
    public abstract class DepartamentoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public DepartamentoCommand()
        {

        }

        public DepartamentoCommand(Guid id, string? descricao)
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