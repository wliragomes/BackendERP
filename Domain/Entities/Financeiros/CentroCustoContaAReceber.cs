namespace Domain.Entities.Financeiros
{
    public class CentroCustoContaAReceber
    {
        public Guid Id { get; set; }
        public string SequenciaPlanoDeContas { get; set; }
        public string Descricao { get; set; }
        public string IdTipoDespesa { get; set; }
    }
}
