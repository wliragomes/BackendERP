using Domain.Entities;

namespace Domain.Commands.Parametros.Atualizar
{
    public class AtualizarParametroCommand : ParametroCommand<AtualizarParametroCommand>
    {
        public AtualizarParametroCommand(Guid id, string nome, string aba, string descricao, bool exibirDescricao, string blocoDescricao, string descricao2, bool exibirDescricao2,
                                         string blocoDescricao2, decimal valor, bool exibirValor, string blocoValor, decimal valor2, bool exibirValor2, string blocoValor2,
                                         bool verdade, bool exibirVerdade, string blocoVerdade, string caixaDeTexto, bool exibirCaixaDeTexto, bool criptografado, string blocoCaixaDeTexto,
                                         string caixaDeTexto2, bool exibirCaixaDeTexto2, bool criptografado2, string blocoCaixaDeTexto2, DateTime caixaDeData, bool exibirCaixaDeData,
                                         string blocoCaixaDeData, DateTime caixaDeData2, bool exibirCaixaDeData2, string blocoCaixaDeData2, string help, bool exibirHelp, string blocoHelp)
            : base(id, nome, aba, descricao, exibirDescricao, blocoDescricao, descricao2, exibirDescricao2, blocoDescricao2, valor, exibirValor, blocoValor, valor2, exibirValor2, blocoValor2,
                                         verdade, exibirVerdade, blocoVerdade, caixaDeTexto, exibirCaixaDeTexto, criptografado, blocoCaixaDeTexto, caixaDeTexto2, exibirCaixaDeTexto2, 
                                         criptografado2, blocoCaixaDeTexto2, caixaDeData, exibirCaixaDeData, blocoCaixaDeData, caixaDeData2, exibirCaixaDeData2, blocoCaixaDeData2, 
                                         help, exibirHelp, blocoHelp)
        {
        }

        public AtualizarParametroCommand()
        {

        }
    }
}