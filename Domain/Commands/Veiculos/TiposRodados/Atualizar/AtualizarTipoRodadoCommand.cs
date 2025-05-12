namespace Domain.Commands.TiposRodados.Atualizar
{
    public class AtualizarTipoRodadoCommand : TipoRodadoCommand<AtualizarTipoRodadoCommand>
    {
        public AtualizarTipoRodadoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarTipoRodadoCommand()
        {

        }
    }
}