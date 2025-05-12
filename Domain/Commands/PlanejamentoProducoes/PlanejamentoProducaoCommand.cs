using SharedKernel.MediatR;

namespace Domain.Commands.PlanejamentoProducaos
{
    public class PlanejamentoProducaoCommand<T> : CommandBase<T>
    {
        public Guid Id { get; set; }
        public Guid? IdOrdemFabricacao { get; set; }
        public Guid? IdOrdemFabricacaoItem { get; set; }
        public Guid? IdComposicao { get; set; }
        public int? SequenciaComposicacao { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Largura { get; set; }
        public int? NPeca { get; set; }
        public int? QtdTotalPeca { get; set; }
        public string? CodigoBarra { get; set; }
        public string? AnoBarra { get; set; }
        public string? CodigoBarraCompleto { get; set; }
        public decimal? ValorM2 { get; set; }
        public decimal? ValorMLinear { get; set; }
        public decimal? ValorPeso { get; set; }
        public decimal? ValorM2Real { get; set; }
        public decimal? ValorMLinearReal { get; set; }
        public decimal? ValorPesoReal { get; set; }
        public decimal? ValorAreaMinima { get; set; }
        public Guid? IdSetorProduto { get; set; }
        public decimal? AlturaLapidacao { get; set; }
        public decimal? LarguraLapidacao { get; set; }
        public DateTime? DataReposicao { get; set; }
        public Guid? IdPlanejamentoComposto { get; set; }
        public bool? Reposicao { get; set; }
        public bool? Reposto { get; set; }
        public PlanejamentoProducaoCommand()
        {

        }

        public PlanejamentoProducaoCommand(Guid id, Guid? idOrdemFabricacao, Guid? idOrdemFabricacaoItem, Guid? idComposicao, int? sequenciaComposicacao, 
                                           decimal? altura, decimal? largura, int? nPeca, int? qtdTotalPeca, string? codigoBarra, string? anoBarra, 
                                           string? codigoBarraCompleto, decimal? valorM2, decimal? valorMLinear, decimal? valorPeso, decimal? valorM2Real,
                                           decimal? valorMLinearReal, decimal? valorPesoReal, decimal? valorAreaMinima, Guid? idSetorProduto, decimal? alturaLapidacao,
                                           decimal? larguraLapidacao, DateTime? dataReposicao, Guid? idPlanejamentoComposto, bool? reposicao, bool? reposto)
        {
            Id = id;
            IdOrdemFabricacao = idOrdemFabricacao;
            IdOrdemFabricacaoItem = idOrdemFabricacaoItem;
            IdComposicao = idComposicao;
            SequenciaComposicacao = sequenciaComposicacao;
            Altura = altura;
            Largura = largura;
            NPeca = nPeca;
            QtdTotalPeca = qtdTotalPeca;
            CodigoBarra = codigoBarra;
            AnoBarra = anoBarra;
            CodigoBarraCompleto = codigoBarraCompleto;
            ValorM2 = valorM2;
            ValorMLinear = valorMLinear;
            ValorPeso = valorPeso;
            ValorM2Real = valorM2Real;
            ValorMLinearReal = valorMLinearReal;
            ValorPesoReal = valorPesoReal;
            ValorAreaMinima = valorAreaMinima;
            IdSetorProduto = idSetorProduto;
            AlturaLapidacao = alturaLapidacao;
            LarguraLapidacao = larguraLapidacao;
            DataReposicao = dataReposicao;
            IdPlanejamentoComposto = idPlanejamentoComposto;
            Reposicao = reposicao;
            Reposto = reposto;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}