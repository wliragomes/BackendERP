using Domain.Commands.MedidasJumbo;
using SharedKernel.MediatR;

namespace Domain.Commands.Parametros
{
    public abstract class ParametroCommand<T> : CommandBase<T>
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
        public List<MedidaJumboCommand>? MedidaJumbo { get; set; }
        public ParametroCommand()
        {

        }

        public ParametroCommand(Guid id, string nome, string aba, string descricao, bool exibirDescricao, string blocoDescricao, string descricao2, bool exibirDescricao2,
                                         string blocoDescricao2, decimal valor, bool exibirValor, string blocoValor, decimal valor2, bool exibirValor2, string blocoValor2,
                                         bool verdade, bool exibirVerdade, string blocoVerdade, string caixaDeTexto, bool exibirCaixaDeTexto, bool criptografado, string blocoCaixaDeTexto,
                                         string caixaDeTexto2, bool exibirCaixaDeTexto2, bool criptografado2, string blocoCaixaDeTexto2, DateTime caixaDeData, bool exibirCaixaDeData,
                                         string blocoCaixaDeData, DateTime caixaDeData2, bool exibirCaixaDeData2, string blocoCaixaDeData2, string help, bool exibirHelp, string blocoHelp)
        {
            Id = id;
            Nome = nome;
            Aba = aba;
            Descricao = descricao;
            ExibirDescricao = exibirDescricao;
            BlocoDescricao = blocoDescricao;
            Descricao2 = descricao2;
            ExibirDescricao2 = exibirDescricao2;
            BlocoDescricao2 = blocoDescricao2;
            Valor = valor;
            ExibirValor = exibirValor;
            BlocoValor = blocoValor;
            Valor2 = valor2;            
            ExibirValor2 = exibirValor2;
            BlocoValor2 = blocoValor2;
            Verdade = verdade;
            ExibirVerdade = exibirVerdade;
            BlocoVerdade = blocoVerdade;
            CaixaDeTexto = caixaDeTexto;
            ExibirCaixaDeTexto = exibirCaixaDeTexto;
            Criptografado = criptografado;
            BlocoCaixaDeTexto = blocoCaixaDeTexto;
            CaixaDeTexto2 = caixaDeTexto2;
            ExibirCaixaDeTexto2 = exibirCaixaDeTexto2;
            Criptografado2 = criptografado2;
            BlocoCaixaDeTexto2 = blocoCaixaDeTexto2;
            CaixaDeData = caixaDeData;
            ExibirCaixaDeData = exibirCaixaDeData;
            BlocoCaixaDeData = blocoCaixaDeData;
            CaixaDeData2 = caixaDeData2;
            ExibirCaixaDeData2 = exibirCaixaDeData2;
            BlocoCaixaDeData2 = blocoCaixaDeData2;
            Help = help;
            ExibirHelp = exibirHelp;
            BlocoHelp = blocoHelp;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}