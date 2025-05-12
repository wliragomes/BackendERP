using SharedKernel.MediatR;

namespace Domain.Commands.Classificacoes
{
    public abstract class ClassificacaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ClassificacaoCommand()
        {

        }

        public ClassificacaoCommand(Guid id, string? nome)
        {
            Id = id;
            Nome = nome;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}