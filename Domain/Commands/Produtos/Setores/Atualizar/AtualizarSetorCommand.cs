namespace Domain.Commands.Produtos.Setores.Atualizar
{
    public class AtualizarSetorCommand : SetorCommand<AtualizarSetorCommand>
    {
        public AtualizarSetorCommand(Guid id, string descricao)
            : base(id, descricao)
        {
        }

        public AtualizarSetorCommand()
        {

        }
    }
}