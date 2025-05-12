namespace Domain.Commands.PlanejamentoProducaos.Atualizar
{
    public class AtualizarPlanejamentoProducaoCommand : PlanejamentoProducaoCommand<AtualizarPlanejamentoProducaoCommand>
    {
        public AtualizarPlanejamentoProducaoCommand(Guid id, Guid? idOrdemFabricacao, Guid? idOrdemFabricacaoItem, Guid? idComposicao, int? sequenciaComposicacao,
                                                   decimal? altura, decimal? largura, int? nPeca, int? qtdTotalPeca, string? codigoBarra, string? anoBarra,
                                                   string? codigoBarraCompleto, decimal? valorM2, decimal? valorMLinear, decimal? valorPeso, decimal? valorM2Real,
                                                   decimal? valorMLinearReal, decimal? valorPesoReal, decimal? valorAreaMinima, Guid? idSetorProduto, decimal? alturaLapidacao,
                                                   decimal? larguraLapidacao, DateTime? dataReposicao, Guid? idPlanejamentoComposto, bool? reposicao, bool? reposto)
            : base(id, idOrdemFabricacao, idOrdemFabricacaoItem, idComposicao, sequenciaComposicacao, altura, largura, nPeca, qtdTotalPeca, codigoBarra, 
                  anoBarra, codigoBarraCompleto, valorM2, valorMLinear, valorPeso, valorM2Real, valorMLinearReal, valorPesoReal, valorAreaMinima, 
                  idSetorProduto, alturaLapidacao, larguraLapidacao, dataReposicao, idPlanejamentoComposto, reposicao, reposto)
        {
        }

        public AtualizarPlanejamentoProducaoCommand()
        {

        }
    }
}