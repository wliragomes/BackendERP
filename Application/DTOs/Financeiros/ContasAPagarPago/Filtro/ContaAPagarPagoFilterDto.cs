namespace Application.DTOs.ContasAPagarPago.Filtro
{
    public class ContaAPagarPagoFilterDto
    {
        public Guid Id { get; set; }
        public Guid IdContaAPagar { get; set; }
        public int NItem { get; set; }
        public string NDocumentoPago { get; set; }

    }
}
