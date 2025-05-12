namespace Domain.Commands.TiposRodados.Adicionar
{
    public class AdicionarTipoRodadoCommand : TipoRodadoCommand<AdicionarTipoRodadoCommand>
    {
        public AdicionarTipoRodadoCommand()
        {

        }

        public AdicionarTipoRodadoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }
    }
}
