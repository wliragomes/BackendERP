using Domain.Commands.Produtos.OrigemMateriais;

namespace Domain.Commands.Produtos.Grupos.Atualizar
{
    public class AtualizarOrigemMaterialCommand : OrigemMaterialCommand<AtualizarOrigemMaterialCommand>
    {
        public AtualizarOrigemMaterialCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarOrigemMaterialCommand()
        {

        }
    }
}
