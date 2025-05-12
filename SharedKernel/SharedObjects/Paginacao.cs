using SharedKernel.Utils;

namespace SharedKernel.SharedObjects
{
    public class Paginacao
    {
        public int? NumeroPagina { get; set; }
        public int? TamanhoPagina { get; set; }
        public int QuantidadeRegistrosFiltrados { get; set; }
        public int QuantidadeTotalRegistros { get; set; }

        public int QuantidadePaginas
        {
            get
            {
                return CacularTotalPaginas();
            }
            private set { }
        }

        public Paginacao(int? numeroPagina, int? tamanhoPagina, int totalRegistros, int quantidadeTotalRegistros)
        {
            NumeroPagina = numeroPagina;
            TamanhoPagina = tamanhoPagina;
            QuantidadeRegistrosFiltrados = quantidadeTotalRegistros;
            QuantidadeTotalRegistros = totalRegistros;
        }

        private int CacularTotalPaginas()
        {
            return (int)Math.Ceiling((decimal)QuantidadeRegistrosFiltrados / (TamanhoPagina ?? ValoresPadroesPaginacao.TamanhoPaginaPadrao));
        }
    }
}
