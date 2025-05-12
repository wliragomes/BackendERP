namespace Domain.Commands.Produtos.Familias.Atualizar
{
    public class AtualizarFamiliaCommand : FamiliaCommand<AtualizarFamiliaCommand>
    {
        public AtualizarFamiliaCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarFamiliaCommand()
        {

        }
    }
}
