namespace Application.DTOs.Pessoas.Filtro
{
    public class CreditoComissaoDto
    {
        public bool? ClienteEspecial { get; set; }
        public decimal? DescontoEspecial { get; set; }
        public bool PraticarLimiteCredito { get; set; }
        public decimal? LimiteCredito { get; set; }
        public bool PraticarInadimplencia { get; set; }
        public int? DiasTolerancia { get; set; }
        public bool ClienteBloqueado { get; set; }
        public string? JustificativaBloqueado { get; set; }
        public bool ClienteSuspenso { get; set; }
        public string? JustificativaSuspenso { get; set; }
        public decimal? ComissaoRepresentante { get; set; }
        public bool ClienteNaoFlutuante { get; set; }
        public bool ExigeInspecaoAgucada { get; set; }
        public bool NaoExigirNumeroPedido { get; set; }
    }
}
