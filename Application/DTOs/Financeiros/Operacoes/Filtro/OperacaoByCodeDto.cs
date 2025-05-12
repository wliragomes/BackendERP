namespace Application.DTOs.Operacoes
{
    public class OperacaoByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool DescontaFinanceiro { get; set; }
        public bool LancaComissao { get; set; }

    }
}
