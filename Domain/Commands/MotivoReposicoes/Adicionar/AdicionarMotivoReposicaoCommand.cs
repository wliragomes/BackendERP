namespace Domain.Commands.MotivoReposições.Adicionar
{
    public class AdicionarMotivoReposicaoCommand : MotivoReposicaoCommand<AdicionarMotivoReposicaoCommand>
    {
        public AdicionarMotivoReposicaoCommand()
        {

        }

        public AdicionarMotivoReposicaoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }
    }
}
