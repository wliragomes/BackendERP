using SharedKernel.MediatR;

namespace Domain.Commands.Cidades
{
    public abstract class CidadeCommand<T> : CommandBase<T>
    {
        public Guid? Id { get; protected set; }
        public Guid IdEstado { get; set; }
        public string Nome { get; protected set; }
        public decimal PrISS { get; set; }
        public decimal ValorMultiplicador { get; set; }
        public string CodIBGE { get; set; }

        public CidadeCommand()
        {

        }

        public CidadeCommand(Guid? id, Guid idEstado, string nome, decimal prISS, decimal valorMultiplicador, string codIBGE)
        {
            Id = id;
            IdEstado = idEstado;
            Nome = nome;
            PrISS = prISS;
            ValorMultiplicador = valorMultiplicador;
            CodIBGE = codIBGE;
        }

        public void SetId(Guid? id)
        {
            Id = id;
        }
    }
}
