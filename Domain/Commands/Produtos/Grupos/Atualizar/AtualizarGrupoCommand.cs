namespace Domain.Commands.Produtos.Grupos.Atualizar
{
    public class AtualizarGrupoCommand : GrupoCommand<AtualizarGrupoCommand>
    {
        public AtualizarGrupoCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarGrupoCommand()
        {

        }
    }
}
