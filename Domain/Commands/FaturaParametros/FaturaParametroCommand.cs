using SharedKernel.MediatR;

namespace Domain.Commands.FaturaParametros
{
    public abstract class FaturaParametroCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public int Modelo { get; set; }
        public string Serie { get; set; }
        public int PrimeiroNumero { get; set; }

        public FaturaParametroCommand()
        {

        }

        public FaturaParametroCommand(Guid id, int modelo, string serie, int primeiroNumero)
        {
            Id = id;
            Modelo = modelo;
            Serie = serie;
            PrimeiroNumero = primeiroNumero;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}