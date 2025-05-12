namespace Domain.Commands.Cfops.Adicionar
{
    public class AdicionarCfopCommand : CfopCommand<AdicionarCfopCommand>
    {
        public AdicionarCfopCommand()
        {

        }

        public AdicionarCfopCommand(Guid id, string? codigoAmigavel, string? codigoLetra, string? codigoCfopLetra, string? dsResumida, string? dsDetalhada,
                                    string? entradaSaida, string? dadosAdicionaisIcms, string? dadosAdicionaisIpi, Guid idCstIcmsOrigemMaterial, Guid idCstIcms,
                                    Guid idCstIpi, Guid idCstPis, Guid idCstCofins, bool? comissao, bool? duplicata, bool? resumo, bool? taxaForaEstado, bool? retorno,
                                    bool? devolucao, bool? mercadoria, bool? producao, bool? vendaOrdem, bool? faturaAutomatica, bool? zerarValor, bool? difal)
            : base(id, codigoAmigavel, codigoLetra, codigoCfopLetra, dsResumida, dsDetalhada, entradaSaida, dadosAdicionaisIcms, dadosAdicionaisIpi, idCstIcmsOrigemMaterial, 
                   idCstIcms, idCstIpi, idCstPis, idCstCofins, comissao, duplicata, resumo, taxaForaEstado, retorno, devolucao, mercadoria, producao, vendaOrdem, faturaAutomatica, zerarValor, 
                   difal)
        {
        }
    }
}
