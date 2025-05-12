namespace Application.DTOs.Emails
{
    public class EnviaEmailOrcamentoDto
    {
        public string Para { get; set; }
        public string Cc { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public AnexoOrcamentoDto AnexoOrcamento { get; set; }
    }
}
