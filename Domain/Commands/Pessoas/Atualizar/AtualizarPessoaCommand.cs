namespace Domain.Commands.Pessoas.Atualizar
{
    public class AtualizarPessoaCommand : PessoaCommand<AtualizarPessoaCommand>
    {
        public AtualizarPessoaCommand(Guid id, bool ativo, bool cliente, bool fornecedor, bool juridica, bool estrangeiro, bool nacional, bool usuario, bool? vendedor, bool motorista, string? cnpjCpf, string? razaoSocial,
                                     string? fantasia, Guid? idRegiao, Guid? idVendedor, string? inscricaoSuframa, bool enviarEmail, bool etiquetaUnit, bool imprimeEtiqueta,
                                     bool etiquetaPorLote, Guid? idOrigem, Guid? idSegmentoCliente, Guid? idSegmentoEstrategico, string? inscricaoMunicipal, string? inscricaoEstadual,
                                     string? cei, List<EnderecoCommand>? enderecos, List<TelefoneCommand>? telefones, List<EmailCommand>? emails,
                                     bool naoContribuinte, bool etiquetaEspecialGuardian, Guid? idTipoConsumidor, bool incideSubstituicaoIcms, bool consumidorFinal, bool industria, 
                                     bool digitarIcms, bool clienteEspecial, decimal descontoEspecial, bool praticarLimiteCredito, decimal limiteCredito, bool praticarInadimplencia,
                                     int diasTolerancia, bool clienteBloqueado, string? justificativaBloqueado, bool clienteSuspenso, string? justificativaSuspenso,
                                     decimal comissaoRepresentante, bool clienteNaoFlutuante, bool exigeInspecaoAgucada, bool naoExigirNumeroPedido)
            : base(id, ativo, cliente, fornecedor, juridica, estrangeiro, nacional, usuario, vendedor, motorista, cnpjCpf, razaoSocial,
                    fantasia, idRegiao, idVendedor, inscricaoSuframa, enviarEmail, etiquetaUnit, imprimeEtiqueta,
                    etiquetaPorLote, idOrigem, idSegmentoCliente, idSegmentoEstrategico, inscricaoMunicipal,
                    inscricaoEstadual, cei, enderecos, telefones, emails,
                    naoContribuinte, etiquetaEspecialGuardian, idTipoConsumidor, incideSubstituicaoIcms,
                    consumidorFinal, industria, digitarIcms, clienteEspecial, descontoEspecial, praticarLimiteCredito, 
                    limiteCredito, praticarInadimplencia, diasTolerancia, clienteBloqueado, justificativaBloqueado, 
                    clienteSuspenso, justificativaSuspenso, comissaoRepresentante, clienteNaoFlutuante, exigeInspecaoAgucada, 
                    naoExigirNumeroPedido)
        {
        }

        public AtualizarPessoaCommand()
        {

        }
    }
}
