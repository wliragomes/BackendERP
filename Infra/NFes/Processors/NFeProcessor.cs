using Application.DTOs.NFes;
using Application.Interfaces.NFes;
using Application.Interfaces.Queries;
using NFE.Builders;
using System.ComponentModel;

namespace Infra.NFes.Processors
{
    public class NFeProcessor : INFeProcessor
    {
        private readonly XmlChaveBuilder _xmlChaveBuilder;
        private readonly XmlIdentificacaoBuilder _xmlIdentificacaoBuilder;
        private readonly XmlEmitenteBuilder _xmlEmitenteBuilder;
        private readonly XmlDestinatarioBuilder _xmlDestinatarioBuilder;
        private readonly XmlEntregaBuilder _xmlEntregaBuilder;
        private readonly XmlIcmsTotalBuilder _xmlIcmsTotalBuilder;
        private readonly XmlTotalBuilder _xmlTotalBuilder;
        private readonly XmlTransporteBuilder _xmlTransporteBuilder;
        private readonly XmlTransportadorBuilder _xmlTransportadorBuilder;
        private readonly XmlVolumeBuilder _xmlVolumeBuilder;
        private readonly XmlVeiculoTransporteBuilder _xmlVeiculoTransporteBuilder;
        private readonly XmlDuplicataBuilder _xmlDuplicataBuilder;
        private readonly XmlCobrancaBuilder _xmlCobrancaBuilder;
        private readonly XmlDetalhesPagamentoBuilder _xmlDetalhesPagamentoBuilder;
        private readonly XmlPagamentoBuilder _xmlPagamento;
        private readonly XmlInformacoesAdicionaisBuilder _xmlInformacoesAdicionaisBuilder;
        private readonly NFeXmlBuilder _xmlBuilder;
        private readonly NFeXmlEnviarBuilder _xmlEnviarBuilder;
        private readonly NFeXmlBuscarBuilder _xmlBuscaBuilder;

        private readonly INFeQuery _NFeQuery;

        public NFeProcessor(INFeQuery NFeQuery)
        {
            _xmlChaveBuilder = new XmlChaveBuilder();
            _xmlIdentificacaoBuilder = new XmlIdentificacaoBuilder();
            _xmlEmitenteBuilder = new XmlEmitenteBuilder();
            _xmlDestinatarioBuilder = new XmlDestinatarioBuilder();
            _xmlEntregaBuilder = new XmlEntregaBuilder();
            _xmlIcmsTotalBuilder = new XmlIcmsTotalBuilder();
            _xmlTransporteBuilder = new XmlTransporteBuilder();
            _xmlTransportadorBuilder = new XmlTransportadorBuilder();
            _xmlVolumeBuilder = new XmlVolumeBuilder();
            _xmlVeiculoTransporteBuilder = new XmlVeiculoTransporteBuilder();
            _xmlDuplicataBuilder = new XmlDuplicataBuilder();
            _xmlCobrancaBuilder = new XmlCobrancaBuilder();
            _xmlDetalhesPagamentoBuilder = new XmlDetalhesPagamentoBuilder();
            _xmlPagamento = new XmlPagamentoBuilder();
            _xmlInformacoesAdicionaisBuilder = new XmlInformacoesAdicionaisBuilder();
            _xmlBuilder = new NFeXmlBuilder();
            _xmlEnviarBuilder = new NFeXmlEnviarBuilder();
            _xmlBuscaBuilder = new NFeXmlBuscarBuilder();

            _NFeQuery = NFeQuery;
        }

        public async Task<NFeResponseDto> EmitirNFe(Guid idFatura, CancellationToken cancellationToken)
        {
            int tipoAmbiente = 1; //1 - Produção, 2 - Homologação
            string nomeCertificado = "";
            string licenca = "";

            try
            {
                ChaveNfeBuscaDto? chaveDto = await _NFeQuery.RetornarChave(idFatura); //Buscar no banco de dados as informações para montar a chave da NFe
                ChaveNFeDto chave = _xmlChaveBuilder.GerarChaveNFe(chaveDto); //Gera a chave da NFe

                identidicacaoNFeDto? ideDto = await _NFeQuery.RetornarIdentificacao(idFatura); //Buscar no banco de dados as informações para montar o grupo IDE na NFe
                string ide = _xmlIdentificacaoBuilder.CriaXmlIdentificacao(ideDto, chave.cNF, chave.numero, chave.cDV, tipoAmbiente); //Montar grupo do xml ide
                
                emitenteNFeDto? emitDto = await _NFeQuery.RetornarEmitente(idFatura); //Buscar no banco de dados as informações para montar o grupo Emitente da NFe
                string emit = _xmlEmitenteBuilder.CriaXmlEmitente(emitDto); //Montar grupo do xml Emitente

                destinatarioNFeDto? destDto = await _NFeQuery.RetornarDestinatario(idFatura); //Buscar no banco de dados as informações para montar o grupo Destinatário da NFe
                string dest = _xmlDestinatarioBuilder.CriaXmlDestinatario(destDto); //Montar grupo do xml Destinatário

                string retirada = ""; //Grupo do xml Retirada

                entregaNFeDto? entregaDto = await _NFeQuery.RetornarEntrega(idFatura); //Buscar no banco de dados as informações para montar o grupo Entrega da NFe
                string entrega = _xmlEntregaBuilder.CriaXmlEntrega(entregaDto); //Montar grupo do xml Entrega

                //detalhes = CriaXmlDetalhes_completo(idFatura);
                string detalhes = "";

                //Falta fazer a rotina para executar a procedure NFeTotalizacao
                icmsTotalNFeDto? icmsTotalDto = await _NFeQuery.RetornarIcmsTotal(idFatura); //Buscar no banco de dados as informações para montar o grupo IcmsTotal da NFe
                string icmsTotal = _xmlIcmsTotalBuilder.CriaXmlIcmsTotal(icmsTotalDto); //Montar grupo do xml IcmsTotal

                string total = _xmlTotalBuilder.CriaXmlTotal(icmsTotal); //Montar grupo do xml Total

                transporteNFeDto? transporteDto = await _NFeQuery.RetornarTransporte(idFatura); //Buscar no banco de dados as informações para montar o grupo Transporte da NFe
                //-------------
                if (transporteDto.modFrete != "9")
                {
                    transportadorNFeDto? transportadorDto = await _NFeQuery.RetornarTransportador(idFatura); //Buscar no banco de dados as informações para montar o grupo Transportador da NFe
                    transporteDto.transporta = _xmlTransportadorBuilder.CriaXmlTransportador(transportadorDto); //Montar grupo do xml Transportador

                    volumeNFeDto? volumeDto = await _NFeQuery.RetornarVolume(idFatura); //Buscar no banco de dados as informações para montar o grupo Volume da NFe
                    transporteDto.transporta = _xmlVolumeBuilder.CriaXmlVolume(volumeDto); //Montar grupo do xml Volume

                    if (transporteDto.cfop != 6)
                    {
                        veiculoTransporteNFeDto? veiculoTransporteDto = await _NFeQuery.RetornarVeiculoTransporte(idFatura); //Buscar no banco de dados as informações para montar o grupo VeiculoTransporte da NFe
                        transporteDto.transporta = _xmlVeiculoTransporteBuilder.CriaXmlVeiculoTransporte(veiculoTransporteDto); //Montar grupo do xml VeiculoTransporte
                    }
                }
                //-------------
                string transporte = _xmlTransporteBuilder.CriaXmlTransporte(transporteDto); //Montar grupo do xml Transporte

                List<duplicataNFeDto>? duplicataDto = await _NFeQuery.RetornarDuplicata(idFatura); //Buscar no banco de dados as informações para montar o grupo Duplicata da NFe
                string duplicata = _xmlDuplicataBuilder.CriaXmlDuplicata(duplicataDto); //Montar grupo do xml Duplicata

                //Falta fazer a rotina para executar a procedure NFeFatura
                cobrancaNFeDto? cobrancaDto = await _NFeQuery.RetornarCobranca(idFatura); //Buscar no banco de dados as informações para montar o grupo Cobranca da NFe
                string cobranca = _xmlCobrancaBuilder.CriaXmlCobranca(cobrancaDto); //Montar grupo do xml Cobranca

                string? detalhesPagamentoDto = await _NFeQuery.RetornarDetalhesPagamento(idFatura); //Buscar no banco de dados as informações para montar o grupo detalhesPagamento da NFe
                string detalhesPagamento = _xmlDetalhesPagamentoBuilder.CriaXmlDetalhesPagamento(detalhesPagamentoDto); //Montar grupo do xml detalhesPagamento

                string pagamemto = _xmlPagamento.CriaXmlPagamento(detalhesPagamento); //Montar grupo do xml Pagamento

                //Falta fazer a rotina para executar a procedure NFeTotalizacao
                informacoesAdicionaisDtoNFeDto? informacoesAdicionaisDto = await _NFeQuery.RetornarInformacoesAdicionais(idFatura); //Buscar no banco de dados as informações para montar o grupo InformacoesAdicionais da NFe
                string infAdic = _xmlInformacoesAdicionaisBuilder.CriaXmlInformacoesAdicionais(informacoesAdicionaisDto); //Montar grupo do xml InformacoesAdicionais

                //Cria xml final
                string xmlFinal = _xmlBuilder.CriaXmlFinal(chave.ChaveNFe, ide, emit, dest, retirada, entrega, detalhes, total, transporte, cobranca, pagamemto, infAdic);

                //Envia xml
                retornoEnvioBuscaNfeDto nfeEnviada = _xmlEnviarBuilder.EnviaNfe(xmlFinal, nomeCertificado, licenca);

                if (nfeEnviada.cStat == 103)
                {
                    //FAZER TRATAMENTO
                    //new SalvaXmlBD().SalvaXml(cod_fatura, xml);
                    retornoEnvioBuscaNfeDto nfeBuscada = _xmlBuscaBuilder.BuscaNfe(nfeEnviada.nfeAssinada, nfeEnviada.nroRecibo, tipoAmbiente, nomeCertificado, licenca);

                    switch (nfeBuscada.cStat)
                    {
                        case 100: //Tudo Certo
                            //Log("NF-e Emitida com sucesso.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 1);
                            //Log("Gerando DaNFe." + Environment.NewLine);
                            //ImprimeDaNFe(xml.XML);
                            break;

                        case 105: //Lote em processamento
                            //Log("Emissao Processamento.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 3);
                            break;

                        case 301: //Denegada
                            //Log("Emissao Denegada.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 1);
                            //ImprimeDaNFe(xml.XML);
                            break;

                        case 302: //Denegada
                            //Log("Emissao Denegada.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 1);
                            //ImprimeDaNFe(xml.XML);
                            break;

                        case 204: //Duplicidade de NF-e
                            //Log("NF-e em duplicidade.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 2);
                            //new nfePendenteBD().AtualizaNfeDuplicidade(id);
                            //new nfePendenteBD().EmailDuplicidade(id);
                            //VoltaNotaSolution(id);
                            break;

                        case 539: //Duplicidade de NF-e, com diferença na Chave de Acesso [99999999999999999999999999999999999999999]
                            //Log("NF-e em duplicidade.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 2);
                            //new nfePendenteBD().AtualizaNfeDuplicidade(id);
                            //new nfePendenteBD().EmailDuplicidade(id);
                            //VoltaNotaSolution(id);
                            break;

                        default:
                            //Log("Erro ao Buscar NF-e na receita.");
                            //new SalvaXmlBD().SalvaXml(id, xml);
                            //new nfePendenteBD().AtualizaNfePendente(id, 4);
                            //VoltaNotaSolution(id);
                            break;
                    }
                }
                else
                {
                    //FAZER TRATAMENTO
                    //new nfePendenteBD().AtualizaNfePendente(cod_fatura, 4);
                    //new SalvaXmlBD().SalvaXml(cod_fatura, xml);
                    //Log("Erro ao enviar NF-e. | " + xml.cStat);
                    //VoltaNotaSolution(cod_fatura);
                }

                return new NFeResponseDto
                {
                    Success = true,
                    Message = $"NFe emitida com sucesso, msgresulado"
                };
            }
            catch (Exception ex)
            {
                return new NFeResponseDto
                {
                    Success = false,
                    Message = $"Erro ao emitir NFe: {ex.Message}"
                };
            }
            
        }
    }

}
