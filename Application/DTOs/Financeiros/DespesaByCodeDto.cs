namespace Application.DTOs.Financeiros
{
    public class DespesaByCodeDto
    {
        public Guid IdCentroDeCusto { get; set; }
        public Guid IdTipoDespesa { get; set; }
        public string DescricaoDepesa { get; set; }

    }
}