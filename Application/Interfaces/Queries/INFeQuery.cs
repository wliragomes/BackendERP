using Application.DTOs.NFes;

namespace Application.Interfaces.Queries
{
    public interface INFeQuery
    {
        Task<ChaveNfeBuscaDto?> RetornarChave(Guid idFatura);
        Task<identidicacaoNFeDto?> RetornarIdentificacao(Guid idFatura);
        Task<emitenteNFeDto?> RetornarEmitente(Guid idFatura);
        Task<destinatarioNFeDto?> RetornarDestinatario(Guid idFatura);
        Task<entregaNFeDto?> RetornarEntrega(Guid idFatura);
        Task<icmsTotalNFeDto?> RetornarIcmsTotal(Guid idFatura);
        Task<transporteNFeDto?> RetornarTransporte(Guid idFatura);
        Task<transportadorNFeDto?> RetornarTransportador(Guid idFatura);
        Task<volumeNFeDto?> RetornarVolume(Guid idFatura);
        Task<veiculoTransporteNFeDto?> RetornarVeiculoTransporte(Guid idFatura);
        Task<List<duplicataNFeDto>?> RetornarDuplicata(Guid idFatura);
        Task<cobrancaNFeDto?> RetornarCobranca(Guid idFatura);
        Task<string?> RetornarDetalhesPagamento(Guid idFatura);
        Task<informacoesAdicionaisDtoNFeDto?> RetornarInformacoesAdicionais(Guid idFatura);
    }
}
