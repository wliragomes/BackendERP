namespace SharedKernel.SharedObjects
{
    public class PaginacaoResponse<T>
    {
        public object? Dados { get; set; }
        public int StatusCode { get; set; } = 200;
        public Paginacao? Paginacao { get; set; }
        public Ordenacao Ordenacao { get; set; }
        public Filtro Filtro { get; set; }

        public void AddData(object dados)
        {
            Dados = dados;
        }

        public void AddPagination(int? numeroPagina, int? tamanhoPagina, int quantidadeTotalRegistros, int quantidadeRegistrosFiltrados)
        {
            Paginacao = new Paginacao(numeroPagina, tamanhoPagina, quantidadeTotalRegistros, quantidadeRegistrosFiltrados);
        }

        public void AddOrder(string? ordenarPor, string? direcaoOrdencao)
        {
            Ordenacao = new Ordenacao(ordenarPor, direcaoOrdencao);
        }

        public void AddFilter(string? ordenarPor, string? valor)
        {
            Filtro = new Filtro(ordenarPor, valor);
        }
    }
}
