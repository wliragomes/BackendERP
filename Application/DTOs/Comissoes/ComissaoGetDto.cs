namespace Application.DTOs.Comissoes
{
    public class ComissaoGetDto
    {
        public Guid Id { get; set; }
        public Guid? IdPessoa { get; set; }
        public Guid? Status { get; set; }
        public DateTime? DataEmissao { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime? DataEmissaoInicial { get; set; }
        public DateTime? DataEmissaoFinal { get; set; }
        public DateTime? DataVencimentoInicial { get; set; }
        public DateTime? DataVencimentoFinal { get; set; }
        public decimal? ValorComissao { get; set; }
        public decimal? Comissao { get; set; }
        public string? RazaoSocial { get; set; }
        public string? RazaoSocialCliente { get; set; }
        public int VendaCodigo { get; set; }
        public int VendaAno { get; set; }
        public DateTime DataEmissaoNotaFiscal { get; set; }
        public DateTime DataDuplicata { get; set; }
        public decimal? ValorDocumento { get; set; }
        

    }
}
