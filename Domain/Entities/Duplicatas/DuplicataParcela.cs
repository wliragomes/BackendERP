using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class DuplicataParcela : Entity
    {
        public Guid IdDuplicata {  get;  set; }
        public int Parcela { get;  set; }
        public decimal ValorDuplicata { get;  set; }
        public string ValorDuplicataExtenso { get;  set; }
        public DateTime DataVencimento { get;  set; }
        public Duplicata Duplicata { get;  set; }

        public DuplicataParcela (Guid idDuplicata, int parcela, decimal valorDuplicata,
            string valorDuplicataExtenso, DateTime dataVencimento)
        {
            IdDuplicata = idDuplicata;
            Parcela = parcela;
            ValorDuplicata = valorDuplicata;
            ValorDuplicataExtenso = valorDuplicataExtenso;
            DataVencimento = dataVencimento;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(int parcela, decimal valorDuplicata,
            string valorDuplicataExtenso, DateTime dataVencimento)
        {
            Parcela = parcela;
            ValorDuplicata = valorDuplicata;
            ValorDuplicataExtenso = valorDuplicataExtenso;
            DataVencimento = dataVencimento;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}