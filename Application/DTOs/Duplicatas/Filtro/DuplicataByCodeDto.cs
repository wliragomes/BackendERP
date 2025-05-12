namespace Application.DTOs.Duplicatas.Filtro
{
    public class DuplicataByCodeDto
    {
        public Guid Id { get; set; }
        public bool? Parcelado { get; set; }
        public string? Numero { get; set; }
        public string? Ano { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? QtdParcelas { get; set; }
        public DateTime? DataEmissao { get; set; }
        public Guid? IdSacado { get; set; }
        public string? Cep { get; set; }
        public string? Endereco { get; set; }
        public Guid? IdCidade { get; set; }
        public Guid? IdEstado { get; set; }
        public string? NumeroEndereco { get; set; }
        public string? Complemento { get; set; }
        public string? CepCobranca { get; set; }
        public string? EnderecoCobranca { get; set; }
        public Guid? IdCidadeCobranca { get; set; }
        public Guid? IdEstadoCobranca { get; set; }
        public string? NumeroEnderecoCobranca { get; set; }
        public string? ComplementoCobranca { get; set; }
        public string? Observacao { get; set; }
        public int? Parcela { get; set; }
        public decimal? ValorDuplicata { get; set; }
        public string? ValorDuplicataExtensao { get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}
