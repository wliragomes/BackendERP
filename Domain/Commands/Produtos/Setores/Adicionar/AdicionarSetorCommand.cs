namespace Domain.Commands.Produtos.Setores.Adicionar
{
    public class AdicionarSetorCommand : SetorCommand<AdicionarSetorCommand>
    {
        public AdicionarSetorCommand()
        {

        }

        public AdicionarSetorCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}