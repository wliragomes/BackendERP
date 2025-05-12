namespace Application.DTOs.ContasBancarias
{
    public class ContaBancariaDto
    {
        public string Descricao { get; set; }
        public Guid IdBanco { get; set; }
        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public string DigitoConta { get; set; }
        public bool LimiteEspecial { get; set; }
        public decimal ValorLimiteEspecial { get; set; }
        public bool ContaGarantida { get; set; }
        public decimal ValorContaGarantida { get; set; }

    }
}
