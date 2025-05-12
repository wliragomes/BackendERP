namespace Domain.Commands.Faturas
{
    public class FaturaTransporteCommand
    {
        public Guid? IdTransportadora { get; set; }
        public Guid? IdTipoFrete { get; set; }
        public string? PlacaVeiculo { get; set; }
        public Guid? IdUFVeiculo { get; set; }
    }
}
