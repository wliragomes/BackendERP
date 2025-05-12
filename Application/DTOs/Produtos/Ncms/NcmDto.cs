namespace Application.DTOs.Produtos.Ncms
{
    public class NcmDto
    {
        public string? NrNcm01 { get; set; }
        public string? NrNcm02 { get; set; }
        public string? NrNcm03 { get; set; }
        public string NrNcmCompleta { get; set; }
        public string Descricao { get; set; }
        public decimal Aliquota { get; set; }
        public bool InsiteSt {  get; set; }
        public decimal AliquotaSt { get; set; }
    }
}
