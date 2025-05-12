using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlIdentificacaoBuilder
    {
        public string CriaXmlIdentificacao(identidicacaoNFeDto ide, string cNF, string numero, string cDV, int tipoAmbiente)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.identificador202006(ide.cUF, Convert.ToInt32(cNF), ide.natOp, ide.mod, ide.serie, ide.nNF, ide.dhEmi, ide.dhSaiEnt, 
                ide.tpNF, ide.idDest, ide.cMunFG, ide.NFref, ide.tpImp, ide.tpEmis, Convert.ToInt32(cDV), tipoAmbiente, ide.finNFe, 
                ide.indFinal, ide.indPres, ide.procEmi, ide.verProc, ide.dhCont, ide.xJust, ide.indIntermed);
        }
    }
}
