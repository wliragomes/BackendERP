using SharedKernel.MediatR;

namespace Domain.Commands.MotivoReposições
{
    public abstract class MotivoReposicaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public MotivoReposicaoCommand()
        {

        }

        public MotivoReposicaoCommand(Guid id, string descricao)
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