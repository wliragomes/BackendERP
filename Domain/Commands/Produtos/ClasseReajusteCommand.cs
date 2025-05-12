using SharedKernel.MediatR;

namespace Domain.Commands.Produtos
{
    public abstract class ClasseReajusteCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        public  ClasseReajusteCommand()
        {
        }
        public ClasseReajusteCommand(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
