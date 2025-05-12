using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class PagarCentroCustoDespesa : Entity
    {
        public Guid IdContaAPagar { get; set; }
        public int NItem { get; set; }
        public Guid IdDespesa { get; set; }
        public Guid IdCentroDeCusto { get; set; }
        public decimal ValorDespesa { get; set; }
        public  ContaAPagar ContaAPagar { get; set; }
        //public PlanoDeContas? Despesa { get; set; }
        //public PlanoDeContas? CentroDeCusto { get; set; }


        public PagarCentroCustoDespesa(Guid idContaAPagar, int nItem, Guid idDespesa, Guid idCentroDeCusto, decimal valorDespesa)
        {
            IdContaAPagar = idContaAPagar;
            NItem = nItem;
            IdDespesa = idDespesa;
            IdCentroDeCusto = idCentroDeCusto;
            ValorDespesa = valorDespesa;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idContaAPagar, int nItem, Guid idClassificacao, Guid idDespesa, Guid idCentroDeCusto, decimal valorDespesa)
        {
            IdContaAPagar = idContaAPagar;
            NItem = nItem;
            IdDespesa = idDespesa;
            IdCentroDeCusto = idCentroDeCusto;
            ValorDespesa = valorDespesa;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
