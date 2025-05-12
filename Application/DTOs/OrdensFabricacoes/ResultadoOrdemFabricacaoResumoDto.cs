namespace Application.DTOs.OrdensFabricacoes
{
    public class ResultadoOrdemFabricacaoResumoDto
    {
        public Guid CD_VENDA { get; set; }
        public int SQ_VENDA_ITEM { get; set; }
        public Guid CD_PRODUTO { get; set; }
        public string CD_AMIGAVEL { get; set; }
        public string NM_PRODUTO { get; set; }
        public decimal QT_VENDIDA { get; set; }
        public decimal QT_PRODUZIDA { get; set; }
        public int QT_PECA { get; set; }
        public decimal VL_M2 { get; set; }
        public decimal VL_PESO { get; set; }
        public decimal VL_M_LINEAR_REAL { get; set; }
        public decimal VL_M_LINEAR { get; set; }
        public decimal QT_PECA_TOTAL { get; set; }
        public decimal VL_M2_TOTAL { get; set; }
        public decimal VL_PESO_TOTAL { get; set; }
        public decimal VL_M_LINEAR_REAL_TOTAL { get; set; }
        public decimal VL_M_LINEAR_TOTAL { get; set; }
    }
}