namespace Domain.Commands.OrdensFabricacoes.Atualizar
{
    public class AtualizarOrdemFabricacaoCommand : OrdemFabricacaoCommand<AtualizarOrdemFabricacaoCommand>
    {
        public AtualizarOrdemFabricacaoCommand(Guid id, Guid idVenda, int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno, Guid idStatus, Guid idPessoa, decimal vidroModulado,
                                               bool chapa, DateTime dataCriacao, DateTime dataEfetivacao, string nomeContato, string telefone, string celular, Guid idEnderecoEntrega,
                                               string obra, string engenheiro, string observacao, bool etiquetaGrandeTemperado, bool descargaCliente, int diasEntrega, DateTime dataEntrega)
            : base(id, idVenda, sqOrdemFabricacaoCodigo, sqOrdemFabricacaoAno, idStatus, idPessoa, vidroModulado, chapa, dataCriacao, dataEfetivacao, nomeContato, telefone, celular,
                  idEnderecoEntrega, obra, engenheiro, observacao, etiquetaGrandeTemperado, descargaCliente, diasEntrega, dataEntrega)
        {
        }

        public AtualizarOrdemFabricacaoCommand()
        {

        }
    }
}