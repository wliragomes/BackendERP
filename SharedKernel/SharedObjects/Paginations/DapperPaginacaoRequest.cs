namespace SharedKernel.SharedObjects.Paginations
{
    public class DapperPaginacaoRequest : PaginacaoRequest
    {
        public string BuildWhereClause()
        {
            var conditions = new List<string>
            {
                "BT_REMOVIDO = 0" // Cláusula fixa
            };
            var parameters = new Dictionary<string, object>();

            // Geração dinâmica de cláusula where
            if (!string.IsNullOrEmpty(ValorFiltro))
            {
                // Adicionar lógica dinâmica
                conditions.Add("(Nome LIKE @SearchTerm)");
                parameters.Add("@SearchTerm", $"%{ValorFiltro}%");
            }

            return conditions.Any()
                ? $" WHERE {string.Join(" AND ", conditions)}"
                : string.Empty;
        }

        public string BuildOrderByClause()
        {
            return $" ORDER BY {OrdenarPor ?? "Nome"} {DirecaoOrdenacao}";
        }
    }
}
