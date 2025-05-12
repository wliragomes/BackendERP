namespace Application.DTOs.NFes
{
    public class destinatarioNFeDto
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string idEstrangeiro { get; set; }
        public string xNome { get; set; }
        public string xLgr { get; set; }
        public string nro { get; set; }
        public string xCpl { get; set; }
        public string xBairro { get; set; }
        public string cMun { get; set; }
        public string xMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string cPais { get; set; }
        private string _xPais { get; set; }
        public string xPais { get; set; }
        public string fone { get; set; }
        public string indIEDest { get; set; }
        public string IE { get; set; }
        public string IESUF { get; set; }
        public string IM { get; set; }
        public string eMail { get; set; }
    }
}
