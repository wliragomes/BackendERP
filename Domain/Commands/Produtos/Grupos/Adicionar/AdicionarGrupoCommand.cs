namespace Domain.Commands.Produtos.Grupos.Adicionar
{
    public class AdicionarGrupoCommand : GrupoCommand<AdicionarGrupoCommand>
    {
        public AdicionarGrupoCommand()
        {

        }

        public AdicionarGrupoCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
