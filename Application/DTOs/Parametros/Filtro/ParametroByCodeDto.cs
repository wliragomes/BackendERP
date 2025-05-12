namespace Application.DTOs.Parametros
{
    public class ParametroByCodeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Aba { get; set; }
        public string Descricao { get; set; }
        public bool ExibirDescricao { get; set; }
        public string BlocoDescricao { get; set; }
        public string Descricao2 { get; set; }
        public bool ExibirDescricao2 { get; set; }
        public string BlocoDescricao2 { get; set; }
        public decimal Valor { get; set; }
        public bool ExibirValor { get; set; }
        public string BlocoValor { get; set; }
        public decimal Valor2 { get; set; }
        public bool ExibirValor2 { get; set; }
        public string BlocoValor2 { get; set; }
        public bool Verdade { get; set; }
        public bool ExibirVerdade { get; set; }
        public string BlocoVerdade { get; set; }
        public string CaixaDeTexto { get; set; }
        public bool ExibirCaixaDeTexto { get; set; }
        public bool Criptografado { get; set; }
        public string BlocoCaixaDeTexto { get; set; }
        public string CaixaDeTexto2 { get; set; }
        public bool ExibirCaixaDeTexto2 { get; set; }
        public bool Criptografado2 { get; set; }
        public string BlocoCaixaDeTexto2 { get; set; }
        public DateTime CaixaDeData { get; set; }
        public bool ExibirCaixaDeData { get; set; }
        public string BlocoCaixaDeData { get; set; }
        public DateTime CaixaDeData2 { get; set; }
        public bool ExibirCaixaDeData2 { get; set; }
        public string BlocoCaixaDeData2 { get; set; }
        public string Help { get; set; }
        public bool ExibirHelp { get; set; }
        public string BlocoHelp { get; set; }
        public MedidaJumboDto MedidaJumbo { get; set; }

    }
}
