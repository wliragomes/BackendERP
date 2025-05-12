using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class CepBloqueado : EntityIdDescricao
    {
        public string NumeroCep { get; set; }
        public int NumeroDe { get; set; }
        public int NumeroAte { get; set; }
        public bool Par { get; set; }
        public bool Impar { get; set; }

        public CepBloqueado(string numeroCep, string descricao, int numeroDe, int numeroAte, bool par, bool impar)
        {
            SetId(Guid.NewGuid());
            NumeroCep = numeroCep;
            SetDescricao(descricao);
            NumeroDe = numeroDe;
            NumeroAte = numeroAte;
            Par = par;
            Impar = impar;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(string numeroCep, string descricao, int numeroDe, int numeroAte, bool par, bool impar)
        {
            NumeroCep = numeroCep;
            SetDescricao(descricao);
            NumeroDe = numeroDe;
            NumeroAte = numeroAte;
            Par = par;
            Impar = impar;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
