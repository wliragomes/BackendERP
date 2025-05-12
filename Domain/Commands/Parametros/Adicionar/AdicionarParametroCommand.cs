namespace Domain.Commands.Parametros.Adicionar
{
    public class AdicionarParametroCommand : ParametroCommand<AdicionarParametroCommand>
    {
        public AdicionarParametroCommand()
        {

        }

        public AdicionarParametroCommand(Guid id, string nome, string aba, string descricao, bool exibirDescricao, string blocoDescricao, string descricao2, bool exibirDescricao2,
                                         string blocoDescricao2, decimal valor, bool exibirValor, string blocoValor, decimal valor2, bool exibirValor2, string blocoValor2,
                                         bool verdade, bool exibirVerdade, string blocoVerdade, string caixaDeTexto, bool exibirCaixaDeTexto, bool criptografado, string blocoCaixaDeTexto,
                                         string caixaDeTexto2, bool exibirCaixaDeTexto2, bool criptografado2, string blocoCaixaDeTexto2, DateTime caixaDeData, bool exibirCaixaDeData,
                                         string blocoCaixaDeData, DateTime caixaDeData2, bool exibirCaixaDeData2, string blocoCaixaDeData2, string help, bool exibirHelp, string blocoHelp)
        {
        }
    }
}
