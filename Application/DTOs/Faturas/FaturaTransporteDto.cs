namespace Application.DTOs.Faturas
{
    public class FaturaTransporteDto
    {
        public Guid? IdTransportadora { get; set; }
        public Guid? IdTipoFrete { get; set; }
        public string? PlacaVeiculo { get; set; }
        public Guid? IdUFVeiculo { get; set; }
    }
}
