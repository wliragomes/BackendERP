using SharedKernel.SharedObjects;

namespace Domain.Entities.Produtos
{
    public class DesgastePolimento : EntityId
    {
        public decimal EspessuraVidroMinimo { get; set; }
        public decimal EspessuraVidroMaximo { get; set; }
        public decimal QuantidadeDesgasteLado { get;  set; }
        public decimal QuantidadeDesgasteTotal { get;  set; }

        public DesgastePolimento(decimal espessuraVidroMinimo, decimal espessuraVidroMaximo, 
                                 decimal quantidadeDesgasteLado, decimal quantidadeDesgasteTotal)
        {
            SetId(Guid.NewGuid());
            EspessuraVidroMinimo = espessuraVidroMinimo;
            EspessuraVidroMaximo =  espessuraVidroMaximo;
            QuantidadeDesgasteLado = quantidadeDesgasteLado;
            QuantidadeDesgasteTotal = quantidadeDesgasteTotal;
            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(decimal espessuraVidroMinimo, decimal espessuraVidroMaximo,
                           decimal quantidadeDesgasteLado, decimal quantidadeDesgasteTotal)
        {
            EspessuraVidroMinimo = espessuraVidroMinimo;
            EspessuraVidroMaximo = espessuraVidroMaximo;
            QuantidadeDesgasteLado = quantidadeDesgasteLado;
            QuantidadeDesgasteTotal = quantidadeDesgasteTotal;
            ChangeUpdateAtToDateTimeNow();
        }
    }
}