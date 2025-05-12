using Application.DTOs.NFes;

namespace NFE.Builders
{
    public class XmlIcmsTotalBuilder
    {
        public string CriaXmlIcmsTotal(icmsTotalNFeDto icmsTotalDto)
        {
            NFe_Util_2G.Util util = new NFe_Util_2G.Util();

            return util.totalICMS400(icmsTotalDto.vBC, icmsTotalDto.vICMS, icmsTotalDto.vBCST, icmsTotalDto.vST, icmsTotalDto.vProd, icmsTotalDto.vFrete,
                icmsTotalDto.vSeg, icmsTotalDto.vDesc, icmsTotalDto.vII, icmsTotalDto.vIPI, icmsTotalDto.vPIS, icmsTotalDto.vCOFINS, icmsTotalDto.vOutro,
                icmsTotalDto.vNF, icmsTotalDto.vTotTrib, icmsTotalDto.vICMSDeson, icmsTotalDto.vICMSUFDest_Opc, icmsTotalDto.vICMSUFRemet_Opc, 
                icmsTotalDto.vFCPUFDest_Opc, icmsTotalDto.vFCP, icmsTotalDto.vFCPST, icmsTotalDto.vFCPSTRet, icmsTotalDto.vIPIDevol);
        }
    }
}
