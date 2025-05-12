using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using SharedKernel.Utils;
using System.Data;
using Dapper;

namespace SharedKernel.Configuration.Extensions
{
    public static class DapperQueryExtensions
    {
        public static async Task<PaginacaoResponse<T>> RetornarFiltroCustomizadoDapper<T>(this IDbConnection connection, DapperPaginacaoRequest paginacaoRequest, string queryBase)
        {
            // Construir cláusulas WHERE e ORDER BY com base na requisição
            var whereClause = paginacaoRequest.BuildWhereClause();
            var orderByClause = paginacaoRequest.BuildOrderByClause();

            // Construir a query de total de registros
            var countQuery = $"{queryBase} {whereClause}";
            var totalRecords = await connection.ExecuteScalarAsync<int>($"SELECT COUNT(*) FROM ({countQuery}) AS Total");

            // Construir a query de paginação
            var skip = paginacaoRequest.ReturnSkip() ?? ValoresPadroesPaginacao.NumeroPaginaPadrao;
            var take = paginacaoRequest.TamanhoPagina ?? ValoresPadroesPaginacao.TamanhoPaginaPadrao;

            var paginatedQuery = $@"
                                    {queryBase}
                                    {whereClause}
                                    {orderByClause}
                                    OFFSET @Skip ROWS 
                                    FETCH NEXT @Take ROWS ONLY";

            // Parâmetros de paginação
            var parameters = new DynamicParameters();
            parameters.Add("@Skip", skip);
            parameters.Add("@Take", take);

            // Obter os dados paginados
            var data = await connection.QueryAsync<T>(paginatedQuery, parameters);

            // Construir a resposta de paginação
            var response = new PaginacaoResponse<T>();
            response.AddPagination(paginacaoRequest.NumeroPagina, paginacaoRequest.TamanhoPagina, totalRecords, data.Count());
            response.AddOrder(paginacaoRequest.OrdenarPor, paginacaoRequest.DirecaoOrdenacao);
            response.AddFilter(paginacaoRequest.FiltrarPor, paginacaoRequest.ValorFiltro);
            response.AddData(data.ToList());

            return response;
        }

        public static async Task<List<T>> RetornarListDapper<T>(this IDbConnection connection, string query, object parametros = null)
        {
            return (await connection.QueryAsync<T>(query, parametros)).ToList();
        }

        public static async Task<T?> RetornarDapper<T>(this IDbConnection connection, string query, object parametros = null)
        {
            return (await connection.QueryAsync<T>(query, parametros)).FirstOrDefault();
        }
    }
}
