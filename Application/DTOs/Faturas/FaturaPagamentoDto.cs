namespace Application.DTOs.Faturas
{
    public class FaturaPagamentoDto
    {
        public int QuantidadeParcelas { get; set; }
        public bool PagamentoAntecipado { get; set; }
        public bool ParcelasPartirPedido { get; set; }
        public bool ParcelasPartirDiasDDL { get; set; }
        public bool PeriodoMensal { get; set; }
        public bool PeriodoDigitada { get; set; }
        public bool PeriodoDias { get; set; }
        public int PeriodoQuantidadeDias { get; set; }
    }
}
