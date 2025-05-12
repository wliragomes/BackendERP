using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class ContaAReceberPago : EntityId
    {
        public Guid? IdContaAReceber { get; set; }
        public int? NItem { get; set; }
        public DateTime? DataBaixa { get; set; }
        public decimal? ValorDocumentoPago { get; set; }
        public string? Historico { get; set; }
        public string? NDocumento { get; set; }

        public ContaAReceberPago(Guid? idContaAReceber, int? nItem, DateTime? dataBaixa, decimal? valorDocumentoPago,
                                 string? historico, string? nDocumento)
        {
            SetId(Guid.NewGuid());
            IdContaAReceber = idContaAReceber;
            NItem = nItem;
            DataBaixa = dataBaixa;
            ValorDocumentoPago = valorDocumentoPago;
            Historico = historico;
            NDocumento = nDocumento;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(DateTime? dataBaixa, decimal? valorDocumentoPago)
        {
            DataBaixa = dataBaixa;
            ValorDocumentoPago = valorDocumentoPago;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
