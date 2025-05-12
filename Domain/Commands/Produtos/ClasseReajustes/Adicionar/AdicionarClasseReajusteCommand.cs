namespace Domain.Commands.Produtos.ClasseReajustes.Adicionar
{
    public class AdicionarClasseReajusteCommand : ClasseReajusteCommand<AdicionarClasseReajusteCommand>
    {
        public AdicionarClasseReajusteCommand()
        {

        }

        public AdicionarClasseReajusteCommand(Guid id, string nome, string? descricao)
            : base(id, nome, descricao) 
        { 
        }
    }
}
