using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class FaturaTemporariaItem : Entity
    {
        public Guid IdFaturaTemporaria { get; set; }
        public int? SqItem { get; set; }
        public Guid? IdProduto { get; set; }
        public decimal? QtdProduto { get; set; }
        public decimal? ValorUnitarioProduto { get; set; }
        public decimal? ValorTotalProduto { get; set; }
        public Guid? IdCfop { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? ValorOutrasDespesas { get; set; }
        public decimal? PrIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? PrIpi { get; set; }
        public decimal? ValorIpi { get; set; }
        public decimal? PrPis { get; set; }
        public decimal? ValorPis { get; set; }
        public decimal? PrCofinss { get; set; }
        public decimal? ValorCofins { get; set; }
        public decimal? PrIva { get; set; }
        public decimal? BaseCalculoSt { get; set; }
        public decimal? ValorSt { get; set; }
        public decimal? ValorNetPrice { get; set; }
        public decimal? ValorGrossPrice { get; set; }
        public FaturaTemporaria FaturaTemporaria { get; set; }

        public FaturaTemporariaItem() { }

        public FaturaTemporariaItem(Guid idFaturaTemporaria, int? sqItem, Guid? idProduto, decimal? qtdProduto, decimal? valorUnitarioProduto, decimal? valorTotalProduto,
                                    Guid? idCfop, decimal? valorFrete, decimal? valorSeguro, decimal? valorOutrasDespesas, decimal? prIcms, decimal? valorIcms, decimal? prIpi,
                                    decimal? valorIpi, decimal? prPis, decimal? valorPis, decimal? prCofinss, decimal? valorCofins, decimal? prIva, decimal? baseCalculoSt,
                                    decimal? valorSt, decimal? valorNetPrice, decimal? valorGrossPrice)
        {
            IdFaturaTemporaria = idFaturaTemporaria;
            SqItem = sqItem;
            IdProduto = idProduto;
            QtdProduto = qtdProduto;
            ValorUnitarioProduto = valorUnitarioProduto;
            ValorTotalProduto = valorTotalProduto;
            IdCfop = idCfop;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            PrIcms = prIcms;
            ValorIcms = valorIcms;
            PrIpi = prIpi;
            ValorIpi = valorIpi;
            PrPis = prPis;
            ValorPis = valorPis;
            PrCofinss = prCofinss;
            ValorCofins = valorCofins;
            PrIva = prIva;
            BaseCalculoSt = baseCalculoSt;
            ValorSt = valorSt;
            ValorNetPrice = valorNetPrice;
            ValorGrossPrice = valorGrossPrice;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idFaturaTemporaria, int? sqItem, Guid? idProduto, decimal? qtdProduto, decimal? valorUnitarioProduto, decimal? valorTotalProduto,
                                    Guid idCfop, decimal? valorFrete, decimal? valorSeguro, decimal? valorOutrasDespesas, decimal? prIcms, decimal? valorIcms, decimal? prIpi,
                                    decimal? valorIpi, decimal? prPis, decimal? valorPis, decimal? prCofinss, decimal? valorCofins, decimal? prIva, decimal? baseCalculoSt,
                                    decimal? valorSt, decimal? valorNetPrice, decimal? valorGrossPrice)
        {
            IdFaturaTemporaria = idFaturaTemporaria;
            SqItem = sqItem;
            IdProduto = idProduto;
            QtdProduto = qtdProduto;
            ValorUnitarioProduto = valorUnitarioProduto;
            ValorTotalProduto = valorTotalProduto;
            IdCfop = idCfop;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            PrIcms = prIcms;
            ValorIcms = valorIcms;
            PrIpi = prIpi;
            ValorIpi = valorIpi;
            PrPis = prPis;
            ValorPis = valorPis;
            PrCofinss = prCofinss;
            ValorCofins = valorCofins;
            PrIva = prIva;
            BaseCalculoSt = baseCalculoSt;
            ValorSt = valorSt;
            ValorNetPrice = valorNetPrice;
            ValorGrossPrice = valorGrossPrice;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
