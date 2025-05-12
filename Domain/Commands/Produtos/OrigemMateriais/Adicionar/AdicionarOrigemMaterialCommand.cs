namespace Domain.Commands.Produtos.OrigemMateriais.Adicionar
{
    public class AdicionarOrigemMaterialCommand : OrigemMaterialCommand<AdicionarOrigemMaterialCommand>
    {
        public AdicionarOrigemMaterialCommand()
        {

        }

        public AdicionarOrigemMaterialCommand(Guid id, string? descricao)
            : base(id, descricao)
        {
        }
    }
}
