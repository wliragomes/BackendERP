namespace Application.DTOs.ContasAPagarPago
{
    public class ContaAPagarPagoByCodeDto
    {
        public Guid Id { get; set; }
        public Guid IdContaAPagar { get; set; }
        public int NItem { get; set; }
        public DateTime Baixa { get; set; }
        public Guid IdBanco { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDigito { get; set; }
        public string Conta { get; set; }
        public string ContaDigito { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataOperacao { get; set; }
        public string Historico { get; set; }
        public string NDocumentoPago { get; set; }

    }
}
