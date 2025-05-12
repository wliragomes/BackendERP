namespace Application.DTOs.Faturas
{
    public class CfopDto
    {        
        public string? CodigoAmigavel { get; set; }
        public string? DsResumida { get; set; }
        public string? CodigoLetra { get; set; }
        public string? CodigoCfopLetra { get; set; }
        public string? DsDetalhada { get; set; }
        public string? EntradaSaida { get; set; }
        public string? DadosAdicionaisIcms { get; set; }
        public string? DadosAdicionaisIpi { get; set; }
        public Guid IdCstIcmsOrigemMaterial { get; set; }
        public Guid IdCstIcms { get; set; }
        public Guid IdCstIpi { get; set; }
        public Guid IdCstPis { get; set; }
        public Guid IdCstCofins { get; set; }
        public bool? Comissao { get; set; }
        public bool? Duplicata { get; set; }
        public bool? Resumo { get; set; }
        public bool? TaxaForaEstado { get; set; }
        public bool? Retorno { get; set; }
        public bool? Devolucao { get; set; }
        public bool? Mercadoria { get; set; }
        public bool? Producao { get; set; }
        public bool? VendaOrdem { get; set; }
        public bool? FaturaAutomatica { get; set; }
        public bool? ZerarValor { get; set; }
        public bool? Difal { get; set; }
    }
}