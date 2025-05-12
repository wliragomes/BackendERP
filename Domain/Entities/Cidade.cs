using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class Cidade : EntityIdNome
    {
        public Guid IdEstado { get; private set; }
        public decimal PrISS { get; private set; }
        public decimal ValorMultiplicador { get; private set; }
        public string CodIBGE { get; private set; }
        public Estado? Estado { get; private set; }

        public Cidade()
        {

        }

        public Cidade(Guid idEstado, string nome, decimal prISS, decimal valorMultiplicador, string codIBGE)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            IdEstado = idEstado;
            PrISS = prISS;
            ValorMultiplicador = valorMultiplicador;
            CodIBGE = codIBGE;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idEstado, string nome, decimal prISS, decimal valorMultiplicador, string codIBGE)
        {
            IdEstado = idEstado;
            SetNome(nome);
            PrISS = prISS;
            ValorMultiplicador = valorMultiplicador;
            CodIBGE = codIBGE;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
