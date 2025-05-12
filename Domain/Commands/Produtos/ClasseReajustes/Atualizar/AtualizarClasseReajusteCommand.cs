namespace Domain.Commands.Produtos.ClasseReajustes.Atualizar
{
    public class AtualizarClasseReajusteCommand : ClasseReajusteCommand<AtualizarClasseReajusteCommand>
    {
        public AtualizarClasseReajusteCommand(Guid id, string nome, string descricao)
            : base(id, nome, descricao)
        {
        }

        public AtualizarClasseReajusteCommand()
        {

        }
    }
}
