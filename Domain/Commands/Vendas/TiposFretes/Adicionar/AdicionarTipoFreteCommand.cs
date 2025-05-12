namespace Domain.Commands.TipoFretes.Adicionar
{
    public class AdicionarTipoFreteCommand : TipoFreteCommand<AdicionarTipoFreteCommand>
    {
        public AdicionarTipoFreteCommand()
        {

        }

        public AdicionarTipoFreteCommand(Guid id, int nFrete, string? descricao, string? descricaoResumida)
            : base(id, nFrete, descricao, descricaoResumida)
        {
        }
    }
}
