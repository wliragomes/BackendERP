namespace Domain.Commands.MotivoReposições.Atualizar
{
    public class AtualizarMotivoReposicaoCommand : MotivoReposicaoCommand<AtualizarMotivoReposicaoCommand>
    {
        public AtualizarMotivoReposicaoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarMotivoReposicaoCommand()
        {

        }
    }
}