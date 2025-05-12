namespace Domain.Commands.TipoFretes.Atualizar
{
    public class AtualizarTipoFreteCommand : TipoFreteCommand<AtualizarTipoFreteCommand>
    {
        public AtualizarTipoFreteCommand(Guid id, int nFrete, string descricao, string descricaoResumida)
            : base(id, nFrete, descricao, descricaoResumida)
        {
        }

        public AtualizarTipoFreteCommand()
        {

        }
    }
}