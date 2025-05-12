namespace Application.DTOs.DashBoards.Filtro
{
    public class DashBoardFilterDto
    {
        public PedidosDto? Pedidos { get; set; }
        public FaturamentoDto? Faturamento { get; set; }
        public NotasEmitidasDto? NotasEmitidas { get; set; }
        public ToneladasAFabricarDto? ToneladasAFabricar { get; set; }
        public OfProducaoDto? OfProducao { get; set; }
    }
}
