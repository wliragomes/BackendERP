namespace Domain.Commands.Produtos.Familias.Adicionar
{
    public class AdicionarFamiliaCommand : FamiliaCommand<AdicionarFamiliaCommand>
    {
        public AdicionarFamiliaCommand()
        {

        }

        public AdicionarFamiliaCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
