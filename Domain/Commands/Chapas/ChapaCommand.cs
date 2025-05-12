using SharedKernel.MediatR;

namespace Domain.Commands.Chapas
{
    public abstract class ChapaCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }


        public ChapaCommand()
        {

        }

        public ChapaCommand(Guid id, string descricao, int altura, int largura)
        {
            Id = id;
            Descricao = descricao;
            Altura = altura;
            Largura = largura;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}