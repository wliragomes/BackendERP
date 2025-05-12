using Domain.Entities.Impostos;
using SharedKernel.SharedObjects;

namespace Domain.Entities.Cfops
{
    public class Cfop : EntityId
    {        
        public string? CodigoAmigavel { get; set; }
        public string? CodigoLetra { get; set; }
        public string? CodigoCfopLetra { get; set; }
        public string? DsResumida { get; set; }
        public string? DsDetalhada { get; set; }
        public string? EntradaSaida { get; set; }
        public string? DadosAdicionaisIcms { get; set; }
        public string? DadosAdicionaisIpi { get; set; }
        public Guid? IdCstIcmsOrigemMaterial { get; set; }
        public Guid? IdCstIcms { get; set; }
        public Guid? IdCstIpi { get; set; }
        public Guid? IdCstPis { get; set; }
        public Guid? IdCstCofins { get; set; }
        public bool? Comissao { get; set; }
        public bool? Duplicata { get; set; }
        public bool? Resumo { get; set; }
        public bool? TaxaForaEstado { get; set; }
        public bool? Retorno { get; set; }
        public bool? Devolucao { get; set; }
        public bool? Mercadoria { get; set; }
        public bool? Producao { get; set; }
        public bool? VendaOrdem { get; set; }
        public bool? FaturaAutomatica { get; set; }
        public bool? ZerarValor { get; set; }
        public bool? Difal { get; set; }
        public CstIcmsOrigemMaterial? CstIcmsOrigemMaterial { get; private set; }
        public CST_ICMS? CST_ICMS { get; private set; }
        public CstIpi? CstIpi { get; private set; }
        public Pis? Pis { get; private set; }
        public Cofins? Cofins { get; private set; }

        public Cfop() { }

        public Cfop(string? codigoAmigavel, string? codigoLetra, string? codigoCfopLetra, string? dsResumida, string? dsDetalhada,
                                    string? entradaSaida, string? dadosAdicionaisIcms, string? dadosAdicionaisIpi, Guid idCstIcmsOrigemMaterial, Guid idCstIcms,
                                    Guid idCstIpi, Guid idCstPis, Guid idCstCofins, bool? comissao, bool? duplicata, bool? resumo, bool? taxaForaEstado, bool? retorno,
                                    bool? devolucao, bool? mercadoria, bool? producao, bool? vendaOrdem, bool? faturaAutomatica, bool? zerarValor, bool? difal)
        {
            SetId(Guid.NewGuid());
            CodigoAmigavel = codigoAmigavel;
            CodigoLetra = codigoLetra;
            CodigoCfopLetra = codigoAmigavel + codigoLetra;
            DsResumida = dsResumida;
            DsDetalhada = dsDetalhada;
            EntradaSaida = entradaSaida;
            DadosAdicionaisIcms = dadosAdicionaisIcms;
            DadosAdicionaisIpi = dadosAdicionaisIpi;
            IdCstIcmsOrigemMaterial = idCstIcmsOrigemMaterial;
            IdCstIcms = idCstIcms;
            IdCstIpi = idCstIpi;
            IdCstPis = idCstPis;
            IdCstCofins = idCstCofins;
            Comissao = comissao;
            Duplicata = duplicata;
            Resumo = resumo;
            TaxaForaEstado = taxaForaEstado;
            Retorno = retorno;
            Devolucao = devolucao;
            Mercadoria = mercadoria;
            Producao = producao;
            VendaOrdem = vendaOrdem;
            FaturaAutomatica = faturaAutomatica;
            ZerarValor = zerarValor;
            Difal = difal;

            SetCreateAtAndUpdateAtToNow();
        }       

        public void Update(string? codigoAmigavel, string? codigoLetra, string? codigoCfopLetra, string? dsResumida, string? dsDetalhada,
                                    string? entradaSaida, string? dadosAdicionaisIcms, string? dadosAdicionaisIpi, Guid idCstIcmsOrigemMaterial, Guid idCstIcms,
                                    Guid idCstIpi, Guid idCstPis, Guid idCstCofins, bool? comissao, bool? duplicata, bool? resumo, bool? taxaForaEstado, bool? retorno,
                                    bool? devolucao, bool? mercadoria, bool? producao, bool? vendaOrdem, bool? faturaAutomatica, bool? zerarValor, bool? difal)
        {            
            CodigoAmigavel = codigoAmigavel;
            CodigoLetra = codigoLetra;
            CodigoCfopLetra = codigoAmigavel + codigoLetra;
            DsResumida = dsResumida;
            DsDetalhada = dsDetalhada;
            EntradaSaida = entradaSaida;
            DadosAdicionaisIcms = dadosAdicionaisIcms;
            DadosAdicionaisIpi = dadosAdicionaisIpi;
            IdCstIcmsOrigemMaterial = idCstIcmsOrigemMaterial;
            IdCstIcms = idCstIcms;
            IdCstIpi = idCstIpi;
            IdCstPis = idCstPis;
            IdCstCofins = idCstCofins;
            Comissao = comissao;
            Duplicata = duplicata;
            Resumo = resumo;
            TaxaForaEstado = taxaForaEstado;
            Retorno = retorno;
            Devolucao = devolucao;
            Mercadoria = mercadoria;
            Producao = producao;
            VendaOrdem = vendaOrdem;
            FaturaAutomatica = faturaAutomatica;
            ZerarValor = zerarValor;
            Difal = difal;

            ChangeUpdateAtToDateTimeNow();
        }
    }
}
