namespace Application.DTOs.ContasAPagar.Filtro
{
    public class ContaAPagarFilterDto
    {
        public Guid Id { get; set; }
        public Guid IdFornecedor { get; set; }
        public string NDocumento { get; set; }
        public decimal ValorDocumento { get; set; }
        public DateTime DataDocumento { get; set; }
        public DateTime DataVencimento { get; set; }
        public string NomeFornecedor { get; set; }

    }
}
