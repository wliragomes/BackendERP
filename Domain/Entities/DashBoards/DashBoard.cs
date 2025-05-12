namespace Domain.Entities.DashBoards
{
    public class DashBoard
    {
        public int QuantidadePedido { get; private set; }
        public int QuantidadePedidoUltimaSemana { get; private set; }
        public int QuantidadeFaturamento { get; private set; }
        public int QuantidadeFaturamentoUltimaSemana { get; private set; }
        public int QuantidadeNotasEmitidas { get; private set; }
        public int QuantidadeNotasEmitidasHoje { get; private set; }
        public int QuantidadeToneladasAFabricar { get; private set; }
        public int QuantidadeToneladasAFabricarHoje { get; private set; }
        public int QuantidadeCorte { get; private set; }
        public int PorcentagemCorte { get; private set; }
        public int QuantidadeTempera { get; private set; }
        public int PorcentagemTempera { get; private set; }
        public int QuantidadeLapidacao { get; private set; }
        public int PorcentagemLapidacao { get; private set; }
        public int QuantidadeLaminacao { get; private set; }
        public int PorcentagemLaminacao { get; private set; }
        public int QuantidadeInsulado { get; private set; }
        public int PorcentagemInsulado { get; private set; }
        public int QuantidadeExpedicao { get; private set; }
        public int PorcentagemExpedicao { get; private set; }
    }
}
