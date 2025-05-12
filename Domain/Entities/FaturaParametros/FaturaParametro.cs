using Domain.Entities.Empresas;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class FaturaParametro : EntityId
    {
        public int Modelo { get; set; }
        public string Serie { get; set; }
        public int PrimeiroNumero { get; set; }
        public ICollection<RelacionaEmpresaFaturaParametro>? RelacionaEmpresaFaturaParametro { get; private set; }

        public FaturaParametro(int modelo, string serie, int primeiroNumero)
        {
            SetId(Guid.NewGuid());
            Modelo = modelo;
            Serie = serie;
            PrimeiroNumero = primeiroNumero;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int modelo, string serie, int primeiroNumero)
        {
            Modelo = modelo;
            Serie = serie;
            PrimeiroNumero = primeiroNumero;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
