using SharedKernel.SharedObjects;

namespace Domain.Entities
{
    public class FaturaTemporaria : EntityId
    {
        public Guid? IdEmpresa { get; set; }
        public Guid? IdPessoa { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorSeguro { get; set; }
        public decimal? ValorOutrasDespesas { get; set; }
        public decimal? PrIcms { get; set; }
        public decimal? ValorIcms { get; set; }
        public decimal? ValorPis { get; set; }
        public decimal? ValorIpi { get; set; }
        public decimal? ValorCofins { get; set; }
        public decimal? BaseCalculoSt { get; set; }
        public decimal? ValorSt { get; set; }
        public decimal? ValorTotalProduto { get; set; }
        public decimal? ValorTotalNota { get; set; }
        public List<FaturaTemporariaItem>? FaturaTemporariaItem { get; set; }

        public FaturaTemporaria() { }

        public FaturaTemporaria(Guid idEmpresa, Guid idPessoa, decimal valorFrete, decimal valorSeguro, decimal valorOutrasDespesas,
                                decimal prIcms, decimal valorIcms, decimal valorPis, decimal valorIpi, decimal valorCofins, decimal baseCalculoSt,
                                decimal valorSt, decimal valorTotalProduto, decimal valorTotalNota)
        {
            SetId(Guid.NewGuid());
            IdEmpresa = idEmpresa;
            IdPessoa = idPessoa;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            PrIcms = prIcms;
            ValorIcms = valorIcms;
            ValorPis = valorPis;
            ValorIpi = valorIpi;
            ValorCofins = valorCofins;
            BaseCalculoSt = baseCalculoSt;
            ValorSt = valorSt;
            ValorTotalProduto = valorTotalProduto;
            ValorTotalNota = valorTotalNota;

            SetCreateAtAndUpdateAtToNow();
        }

        public void Update(Guid idEmpresa, Guid idPessoa, decimal valorFrete, decimal valorSeguro, decimal valorOutrasDespesas,
                            decimal prIcms, decimal valorIcms, decimal valorPis, decimal valorIpi, decimal valorCofins, decimal baseCalculoSt,
                            decimal valorSt, decimal valorTotalProduto, decimal valorTotalNota)
        {
            IdEmpresa = idEmpresa;
            IdPessoa = idPessoa;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            ValorOutrasDespesas = valorOutrasDespesas;
            PrIcms = prIcms;
            ValorIcms = valorIcms;
            ValorPis = valorPis;
            ValorIpi = valorIpi;
            ValorCofins = valorCofins;
            BaseCalculoSt = baseCalculoSt;
            ValorSt = valorSt;
            ValorTotalProduto = valorTotalProduto;
            ValorTotalNota = valorTotalNota;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
