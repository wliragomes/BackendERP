using Domain.Entities.Produtos;
using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class OrdemFabricacaoItemTemporaria : EntityId
    {
        public Guid IdVenda { get; set; }
        public int SqVendaItem { get; set; }
        public decimal Altura { get; set; }
        public decimal Largura { get; set; }
        public decimal ValorM2 { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorPeso { get; set; }
        public decimal ValorMLinearReal { get; set; }
        public decimal ValorMLinear { get; set; }


        public OrdemFabricacaoItemTemporaria(Guid idVenda, int sqVendaItem, decimal altura, decimal largura, decimal valorM2, int quantidade,
                                             decimal valorPeso, decimal valorMLinearReal, decimal valorMLinear)
        {
            SetId(Guid.NewGuid());
            IdVenda = idVenda;
            SqVendaItem = sqVendaItem;
            Altura = altura;
            Largura = largura;
            ValorM2 = valorM2;
            Quantidade = quantidade;
            ValorPeso = valorPeso;
            ValorMLinearReal = valorMLinearReal;
            ValorMLinear = valorMLinear;

            SetCreateAtAndUpdateAtToNow();
            ChangeUpdateAtToDateTimeNow();
        }        
    }
}
