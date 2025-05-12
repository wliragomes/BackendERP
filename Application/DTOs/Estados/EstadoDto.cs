namespace Application.DTOs.Estados
{
    public class EstadoDto
    {
        public Guid? IdPais { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }
        public string? CodIBGE { get; set; }
        public decimal? AliquotaIcmsInterestadual { get; set; }
        public decimal? AliquotaIcmsInterna { get; set; }
        public decimal? AliquotaIcmsDiferenca { get; set; }
    }
}
